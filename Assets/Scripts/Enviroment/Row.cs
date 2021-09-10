using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Ряд с окружением
/// </summary>
public class Row : MonoBehaviour
{
    [SerializeField] Transform leftSpawnPoints;
    [SerializeField] Transform centerSpawnPoint;
    [SerializeField] Transform rightSpawnPoint;

    [SerializeField] Food food;
    [SerializeField] BadFood badFood;
    [SerializeField] Obstacle obstacle;
    [SerializeField] Gem gem;


    Transform[] transformPoints;
    ColorPath colorPath;
    void Awake()
    {
        transformPoints = new Transform[3];
        transformPoints[0] = leftSpawnPoints;
        transformPoints[1] = rightSpawnPoint;
        transformPoints[2] = centerSpawnPoint;
        colorPath = GetComponentInParent<ColorPath>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            CreateFood(food, 0, colorPath.GetColorGood);
            CreateFood(badFood, 1, colorPath.GetColorBad);
        }
        else if(ind > 5)
        {
            CreateFood(food, 1, colorPath.GetColorGood);
            CreateFood(badFood, 0, colorPath.GetColorBad);
        }
    }

    /// <summary>
    /// Создание препядствий и Гемаов
    /// </summary>
    internal void CreatObstacleAndGem()
    {
        int ind = Random.Range(0, 3);
        print(ind);
        if (ind == 0)
        {
            CreateGem(0);
            CreateObstacle(1);
            CreateObstacle(2);
        }
        else if (ind == 1)
        {
            CreateObstacle(0);
            CreateGem(1);
            CreateObstacle(2);
        }

        else if (ind == 2)
        {
            CreateGem(2);
            CreateObstacle(1);
            CreateObstacle(0);
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
