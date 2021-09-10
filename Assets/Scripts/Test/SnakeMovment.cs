using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
public class SnakeMovment : MonoBehaviour {

	public float Speed;
	public float RotationSpeed;
	public List<GameObject> tailObjects = new List<GameObject>();
	public float z_offset = 0.5f;
	public float startSpeed ;
	Touch touch;
	Vector2 touchStart;
	Vector2 touchEnd;
	Sequence sequence;

	public Transform[] points;
	[SerializeField] Transform movepoint;

	int indexPoint = 1;
	float flag;
	Vector3 v;
	void Start () {
		v = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
		startSpeed = Speed;
		transform.LookAt(points[2].position);
	}
	void Update () 
	{

		//ChangePosition();


		transform.Translate(Vector3.forward * Speed*Time.deltaTime);
		
		//transform.LookAt(movepoint.position);

		//if(Input.GetKey(KeyCode.D))
		//{
		//	//if(indexPoint == 1)
		//	//         {
		//	//	Vector3 v = transform.position;
		//	//	v = new Vector3(v.x + 10f, v.y, v.z + 10);
		//	//	transform.DOLookAt(v, 1);
		//	//	transform.DOMove(v, 1);
		//	//	StartCoroutine(LookAt());
		//	//}			

		//	transform.Rotate(Vector3.up * 1 * RotationSpeed * Time.deltaTime);
		//}
		//else if(Input.GetKey(KeyCode.A))
		//{
		//	transform.Rotate(Vector3.up*-1*RotationSpeed*Time.deltaTime);
		//}


	}

	//public void AddTail()
	//{
	//	score++;
	//	Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
	//	newTailPos.z -= z_offset;
	//	tailObjects.Add(GameObject.Instantiate(TailPrefab,newTailPos,Quaternion.identity) as GameObject);
	//}

	IEnumerator LookAt()
    {
        yield return new WaitForSeconds(1);
		transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 5));
	}

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
					//transform.position = new Vector3(rangePos * (x / 200), transform.position.y, transform.position.z);
				}

			}
		}


		if (flag < -1)
		{

			transform.LookAt(new Vector3(-30f, transform.position.y, transform.position.z));
			transform.DOMove(new Vector3(-30f, transform.position.y, transform.position.z), 1);
			transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 1);

		}
		else if (flag > 1)
		{

			transform.LookAt(new Vector3(30f, transform.position.y, transform.position.z));
			transform.DOMove(new Vector3(30f, transform.position.y, transform.position.z), 1);
			transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 1);

		}
		else if (flag < 1 && flag > -1)
		{

			transform.DOLookAt(new Vector3(0f, transform.position.y, transform.position.z), 1);
			transform.DOMove(new Vector3(0f, transform.position.y, transform.position.z), 1);
			transform.DOLookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 1);
		}
	}
}
