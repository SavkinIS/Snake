using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    /// <summary>
    /// MeshRenderer Дочерних объектов для получения цвета
    /// </summary>
    [SerializeField] MeshRenderer[] childrensColor;
    protected GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// Изменит цвет всем дочерним элементам
    /// </summary>
    /// <param name="newcolor"></param>
    internal void SetColor(Color newcolor)
    {
        foreach (var item in childrensColor)
        {
            item.material.color = newcolor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Check(other);
    }

    /// <summary>
    /// Проверит является ли обект головой змеи и унчтожит gameObject
    /// </summary>
    /// <param name="other"></param>
    private protected void Check(Collider other)
    {
        if (other.TryGetComponent<MoveHead>(out MoveHead snake))
        {
            manager.AppPoints();
            Destroy(gameObject);
        }
    }
}
