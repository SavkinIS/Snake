using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gem : MonoBehaviour
{

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 180, 0), 2f,RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);

        manager = FindObjectOfType<GameManager>();
    }


    void OnTriggerEnter(Collider colider)
    {
        if (colider.TryGetComponent(out MoveHead snake))
        {
            manager.AddGem();
            Destroy(gameObject);
        }
    }
}
