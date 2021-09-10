using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TailMovment : MonoBehaviour {

	public float Speed;
	public Vector3 tailTarget;
	public int indx;
	public GameObject tailTargetObj;
	public SnakeMovment mainSnake;
	void Start()
	{

		mainSnake = FindObjectOfType<SnakeMovment>();
		Speed = mainSnake.Speed+2.5f;
		indx = mainSnake.tailObjects.IndexOf(gameObject);
		if(indx != 0)tailTargetObj = mainSnake.tailObjects[indx - 1];
        else { tailTargetObj = mainSnake.gameObject; }
	}
	void Update () {
		
			tailTarget = tailTargetObj.transform.position;
			transform.LookAt(tailTarget);
			transform.position = Vector3.Lerp(transform.position,tailTarget, mainSnake.Speed*Time.deltaTime);
			//transform.DOMove(tailTarget, 0.5f);
		
		
	}

	
	
}
