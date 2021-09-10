using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ряд с окружением
/// </summary>
public class Row : MonoBehaviour
{
    [Tooltip("left Spawn Points")]
    [SerializeField] Transform leftSpawnPoints;
    [Tooltip("center Spawn Points")]
    [SerializeField] Transform centerSpawnPoint;
    [Tooltip("right Spawn Points")]
    [SerializeField] Transform rightSpawnPoint;

    [SerializeField] Food food;
    [SerializeField] BadFood badFood;
    [SerializeField] Obstacle obstacle;
    [SerializeField] Gem gem;

    /// <summary>
    /// Array with spawn Points
    /// </summary>
    Transform[] transformPoints;
    ColorPath colorPath;

    /// <summary>
    /// side constants
    /// </summary>
    const int left = 0;
    const int right = 1;
    const int center = 2;
    void Awake()
    {
        transformPoints = new Transform[3];
        transformPoints[0] = leftSpawnPoints;
        transformPoints[1] = rightSpawnPoint;
        transformPoints[2] = centerSpawnPoint;
        colorPath = GetComponentInParent<ColorPath>();
        
    }


    /// <summary>
    /// Создание еды
    /// </summary>
   internal void CreateWithoutObstacle() 
    {
        Food f;
        BadFood bF;
        int ind = Random.Range(0, 10);
        if(ind <= 5)
        {
            CreateFood(food, left, colorPath.GetColorGood);
            CreateFood(badFood, right, colorPath.GetColorBad);
        }
        else if(ind > 5)
        {
            CreateFood(food, right, colorPath.GetColorGood);
            CreateFood(badFood, left, colorPath.GetColorBad);
        }
    }

    /// <summary>
    /// Создание препядствий и Гемаов
    /// </summary>
    internal void CreatObstacleAndGem()
    {
        int ind = Random.Range(left, center+1);
        print(ind);
        if (ind == 0)
        {
            CreateGem(left);
            CreateObstacle(right);
            CreateObstacle(center);
        }
        else if (ind == 1)
        {
            CreateObstacle(left);
            CreateGem(right);
            CreateObstacle(center);
        }

        else if (ind == 2)
        {
            CreateGem(center);
            CreateObstacle(right);
            CreateObstacle(left);
        }
    }

    /// <summary>
    /// Создание еды
    /// </summary>
    /// <param name="indx"></param>
    void CreateFood(Food food, int indx, Color color)
    {
       Food f = Instantiate(food, transformPoints[indx].position, Quaternion.identity, transformPoints[indx]);
        f.SetColor(color);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="gem"></param>
    /// <param name="indx">Индекс точки появления</param>
    void CreateGem(int indx)
    {
        Instantiate(gem, transformPoints[indx].position, Quaternion.identity, transformPoints[indx]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obstacle"></param>
    /// <param name="indx">Индекс точки появления</param>
    void CreateObstacle(int index)
    {
        Instantiate(obstacle, transformPoints[index].position, Quaternion.identity, transformPoints[index]);
    }


}
