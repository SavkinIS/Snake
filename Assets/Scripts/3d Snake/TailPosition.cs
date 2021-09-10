using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace NewSnake
{
    public class TailPosition : MonoBehaviour
    {

        [SerializeField]
        Transform tailPos;

        public Transform GetTransform()
        {
            return tailPos;
        }
    }
}
