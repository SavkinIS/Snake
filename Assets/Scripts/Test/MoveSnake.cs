using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnake : MonoBehaviour
{

    Touch touch;
    Vector2 touchStart;
    Vector2 touchEnd;
    float flag;
    public Transform[] points;
    

    public List<Transform> bodyParts = new List<Transform>();


    public float minDistance = 0.25f;

    public int beginSize;

    public float speed = 1;
    public float rotationSpeed = 50;

    public GameObject bodyprefabs;

    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;
    float distancePartX;


    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < beginSize - 1; i++)
        //{

        //    AddBodyPart();

        //}
        distancePartX = bodyParts[0].lossyScale.x;
        print(distancePartX);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangePosition();

        //if (Input.GetKey(KeyCode.Q))
        //    AddBodyPart();
    }

    public void Move()
    {

        float curspeed = speed;

        if (Input.GetKey(KeyCode.W))
            curspeed *= 2;

        bodyParts[0].Translate(bodyParts[0].forward * curspeed * Time.deltaTime, Space.World);

        //if (Input.GetAxis("Horizontal") != 0)
        //    bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        for (int i = 1; i < bodyParts.Count; i++)
        {

            curBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];

            dis = Vector3.Distance(PrevBodyPart.position, curBodyPart.position);

            Vector3 newpos = PrevBodyPart.position;

            newpos.y = bodyParts[0].position.y;

            float T = Time.deltaTime * dis/minDistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodyPart.rotation, T);



        }
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
          
            transform.LookAt(new Vector3( -30f,bodyParts[0].transform.position.y, bodyParts[0].transform.position.z ));
            transform.DOMove(new Vector3(-30f, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z),1);
            transform.DOLookAt(new Vector3(bodyParts[0].transform.position.x, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z + 1), 1);

        }
        else if (flag > 1)
        {
           
            transform.LookAt(new Vector3(30f, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z));
            transform.DOMove(new Vector3(30f, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z),1);
            transform.DOLookAt(new Vector3(bodyParts[0].transform.position.x, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z + 1), 1);

        }
        else if (flag < 1 && flag > -1)
        {
         
            transform.DOLookAt(new Vector3(0f, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z),1);
            transform.DOMove(new Vector3(0f, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z),1);
            transform.DOLookAt(new Vector3(bodyParts[0].transform.position.x, bodyParts[0].transform.position.y, bodyParts[0].transform.position.z + 1), 1);
        }
    }


    public void AddBodyPart()
    {

        Transform newpart = (Instantiate(bodyprefabs, new Vector3(  bodyParts[bodyParts.Count - 1].position.x, bodyParts[bodyParts.Count - 1].position.y, -distancePartX), bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;
        newpart.localScale = transform.localScale;
        newpart.SetParent(transform);
        distancePartX+= bodyParts[0].lossyScale.x;

        bodyParts.Add(newpart);
    }
}
