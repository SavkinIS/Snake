using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewSnake
{
    public class PerentsPosirion : MonoBehaviour
    {
        [Range (0.1f, 5f)]
        [SerializeField] float maxDist;
        MoveHead moveHead;
        int currentIndx;
        Transform parent;
        Vector3 distance;
        Transform parentsTail;

        float timer;
        // Start is called before the first frame update
        void Start()
        {
            timer = 0.1f;
            moveHead = FindObjectOfType<MoveHead>();
            currentIndx = moveHead.GetIndexInTail(this);
            if (currentIndx == 0) parent = moveHead.transform;
            else
            {
                parent = moveHead.GetParentTail(currentIndx-1).transform;
            }
            distance = parent.position - transform.position;
            parentsTail = parent.GetComponent<TailPosition>().GetTransform();
        }

        // Update is called once per frame
        void Update()
        {
           transform.LookAt(parent.position);
            timer -= Time.deltaTime;
            //if (currentIndx == 0) maxDist *=1f;
            if (timer <= 0 )
            {
                //if(transform.localPosition.x == 30))
                transform.position = Vector3.MoveTowards(transform.position, parentsTail.position, maxDist);
                timer = 0.02f;
            }


            if (transform.localPosition.x > 5) transform.localPosition = new Vector3(5, transform.localPosition.y, transform.localPosition.z);
            else if (transform.localPosition.x <- 5) transform.localPosition = new Vector3(-5, transform.localPosition.y, transform.localPosition.z);


        }

    }
}
