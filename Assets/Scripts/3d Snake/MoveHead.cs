using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace NewSnake {
    public class MoveHead : MonoBehaviour
    {

		[Tooltip("Точки креплнния деталей хвоста к вышестоящей части")]
		[SerializeField]
		List<ParentsPosition> parentsPosirions = new List<ParentsPosition>();

        [Tooltip("Точки для вращения головой")]
        [SerializeField] Transform[] points;

        [SerializeField]
        Joystick fixedJoystick;

        [Tooltip("скорость перемещения")]//30
        [SerializeField]
        float speed;

        [Tooltip("Ограничение дял движеня по X координатам ")]
        [SerializeField]
        private float limitX;
        [Tooltip("Cкорость поворота ")]//150
        [SerializeField]
        private float speedRotation;


        /// <summary>
        /// Угол поворота
        /// </summary>
        const float angleY = 90f;

        Touch touch;
        /// <summary>
        /// начальное косание
        /// </summary>
		Vector2 touchStart;
        /// <summary>
        /// Конесное косание
        /// </summary>
		Vector2 touchEnd;

        /// <summary>
        /// Значение для позиций змеи
        /// </summary>
		float flag;
        /// <summary>
        /// Движется ли змея
        /// </summary>
		bool moving;
        /// <summary>
        /// Х от точки в которую движется змея
        /// </summary>
		float needPoint;
        /// <summary>
        /// Начальный поворот головы змеи
        /// </summary>
		Quaternion quaternionStart;

        /// <summary>
        /// Точка в которую должна прийти змея
        /// </summary>
		Vector3 pointPos;
        /// <summary>
        /// Точка в которую должна смотреть змея
        /// </summary>
		Transform loockPoint;

		Material material;

        /// <summary>
        /// Materials деталей хвоста
        /// </summary>
		List<Material> Materials = new List<Material>();

        /// <summary>
        /// Таймер ярости
        /// </summary>
        float timerOfRage;
        

        /// <summary>
        /// находиться ли змея в ярости
        /// </summary>
        bool isRage;

        /// <summary>
        /// Вернёт сотояние ярости
        /// </summary>
        internal bool GetIsRage => isRage;


        /// <summary>
        /// значение Х относительно джостика(-1,1)
        /// </summary>
        float xThrow, xOffset;
        /// <summary>
        /// новая позиция по коодинате Х
        /// </summary>
        private float  rawNewXPosNew;
        /// <summary>
        /// предыдущая позиция позиция 
        /// </summary>
        private Vector3 lastPosition;

        /// <summary>
        /// граница смещения для поворота
        /// </summary>
        private const float offsetX = 0.05f;



        // Start is called before the first frame update
        void Start()
        {

            timerOfRage = 0f;
			quaternionStart = transform.rotation;
			moving = false;
			material = GetComponent<MeshRenderer>().material;
			foreach (var tail in parentsPosirions)
			{
				Materials.Add(GetTailMaterial(tail));
			}
            isRage = false;

		}

        // Update is called once per frame
        void Update()
        {
            
            if (timerOfRage > 1f)
            {
                MiddlePosition();
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, 0), 1);
            }
			timerOfRage -= Time.deltaTime;

            if (timerOfRage <= 0)
            {
                ProcessPosition();
                isRage = false;
                
            }
            

            //if (loockPoint != null)
            //    transform.LookAt(loockPoint.position);

        }



        /// <summary>
        /// Управление позиций змеи кнопками
        /// </summary>
        private void ChangePOsitioWithButtons()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                pointPos = new Vector3(-30f, transform.position.y, transform.position.z + 7);
                print(quaternionStart);
                moving = true;
                flag = 1;
                needPoint = -30f;
                transform.localRotation = Quaternion.Euler(0, -90f, 0);
                transform.LookAt(points[0].position);

                transform.DOMove(points[0].position, 1f);

                loockPoint = points[0];

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MiddlePosition();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                pointPos = new Vector3(30f, transform.position.y, transform.position.z + 7);

                print(quaternionStart);
                moving = true;
                flag = -1;
                needPoint = 30f;
                transform.LookAt(points[2].position);
                transform.DOMove(points[2].position, 1f);
                if (transform.position.x > 30f)
                {

                }
                loockPoint = points[2];
            }
        }


        /// <summary>
        /// устоновить позицию змеи на центр
        /// </summary>
        private void MiddlePosition()
        {
            pointPos = new Vector3(0f, transform.position.y, transform.position.z + 7);
            //print(quaternionStart);
            //if (transform.position.x > -30 && transform.position.x < 0)
            //{
            //    transform.LookAt(pointPos);
            //}
            //else if (transform.position.x <= 30 && transform.position.x > 0)
            //{
            //    transform.LookAt(pointPos);
            //}


            moving = true;
            flag = 0;
            needPoint = 0f;
            //transform.LookAt(points[1].position);
            transform.DOMove(points[1].position, 1f);
            loockPoint = points[1];
        }

        /// <summary>
        /// Установит свет у головы и деталей хвоста
        /// </summary>
        /// <param name="color"></param>
        internal void SetColor(Color color)
        {
            material.color = color;
			
            foreach (var material in Materials)
            {
				material.color = color;
            }
		}

        /// <summary>
        /// Изменение позиций
        /// </summary>
        void ChangePosition()
		{
			if (Input.touchCount > 0)
			{
				touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{
					touchStart = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
				{
					touchEnd = touch.position;
					float x = touchEnd.x - touchStart.x;
					float y = touchEnd.y - touchStart.y;
					if (Mathf.Abs(x) > Mathf.Abs(y))
					{
						flag = (x / 200);
					}

				}
			}
			moving = true;

			if (flag < -1 && transform.position.x!= -30f)
			{
                pointPos = new Vector3(-30f, transform.position.y, transform.position.z + 7);
                print(quaternionStart);
                moving = true;
                flag = 1;
                needPoint = -30f;
                transform.localRotation = Quaternion.Euler(0, -90f, 0);
                transform.LookAt(points[0].position);

                transform.DOMove(points[0].position, 1f);

                loockPoint = points[0];
            }
			else if (flag > 1 && transform.position.x != 30f)
			{
                pointPos = new Vector3(30f, transform.position.y, transform.position.z + 7);

                print(quaternionStart);
                moving = true;
                flag = -1;
                needPoint = 30f;
                transform.LookAt(points[2].position);
                transform.DOMove(points[2].position, 1f);
                if (transform.position.x > 30f)
                {

                }
                loockPoint = points[2];
            }
			else if (flag < 1 && flag > -1 && transform.position.x != 0f)
			{
                MiddlePosition();
            }

			//transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 1);
		}

        /// <summary>
        /// Изменение позиций
        /// </summary>
        void ProcessPosition()
        {
            var posChanged = Mathf.Abs( transform.localPosition.x - lastPosition.x);
            xThrow = fixedJoystick.Horizontal;
            print(posChanged.ToString());
            
                if (xThrow > offsetX && transform.localRotation.eulerAngles.y < angleY && transform.localPosition.x< limitX)
                {
                    transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
                    transform.LookAt(points[2].position);
                }
                else if (xThrow < -offsetX && transform.localRotation.eulerAngles.y > -angleY && transform.localPosition.x >-limitX)
                {
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, -angleY, 0), 1);
                    transform.LookAt(points[0].position);
                }
                else
                {
                    transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1);
                print(transform.localRotation.eulerAngles.y.ToString() + " прямо");
                //transform.LookAt(points[1].position);
            }
            
            xOffset = xThrow * speed * Time.deltaTime;
            rawNewXPosNew = transform.localPosition.x + xOffset;

            //


            transform.localPosition = new Vector3(Mathf.Clamp(rawNewXPosNew, -limitX, limitX),
                                                   transform.localPosition.y,
                                                  transform.localPosition.z);


            lastPosition = transform.localPosition;
        }


        void AddTails(){}

        /// <summary>
        /// Вернет идекс чати хвоста
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
		public int GetIndexInTail(ParentsPosition item)
		{
			return parentsPosirions.IndexOf(item);
		}

        /// <summary>
        /// Веренет объукт к которому прикреплён
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public ParentsPosition GetParentTail(int index)
		{
			return parentsPosirions[index];
		}


        /// <summary>
        /// Поллучит Material элемента хвоста
        /// </summary>
        /// <param name="tail"></param>
        /// <returns></returns>
		Material GetTailMaterial(ParentsPosition tail)
        {
			return tail.GetComponent<MeshRenderer>().material;
        }

        /// <summary>
        /// Вхождение в режим ярости
        /// </summary>
        /// <param name="durationOfRage"></param>
		public void Rage(float durationOfRage)
        {
            timerOfRage = durationOfRage+1f;
            isRage = true;
            MiddlePosition();
        }

        /// <summary>
        /// Уничтожение змеи с дуталями хвоста
        /// </summary>
        internal void Destroy()
        {
            foreach (var item in parentsPosirions)
            {
                Destroy(item.gameObject);
            }
            Destroy(gameObject);
        }
    }
}

