using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPath : MonoBehaviour
{

    [SerializeField] Color[] colors;
    CreateEnviroment path;
    
    [SerializeField] Row rowPrefab;
    [SerializeField] float distanceZ;

    float constdistanceZ;
    Color colorGood;
    Color colorBad;
    public Color GetColorGood => colorGood;
    public Color GetColorBad => colorBad;
    float maxPoint;
    //public void SetMaxPoint(float value) => maxPoint = value;

    void Start()
    {
        path = FindObjectOfType<CreateEnviroment>();
        constdistanceZ = distanceZ;
        int i = Random.Range(0,colors.Length-1);
        colorGood = colors[i];
        int j = Random.Range(0, colors.Length-1);
        while (j == i)
        {
            j = Random.Range(0, colors.Length-1);
        }
        colorBad = colors[j];
        maxPoint = path.pathPartLenth;


        while (distanceZ < maxPoint)
        {
            CreateRow();
        }
        transform.parent = FindObjectOfType<CreateEnviroment>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CreateRow()
    {
        Row row = Instantiate(rowPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + distanceZ), Quaternion.identity, transform);
        if (distanceZ > maxPoint / 2) row.CreatObstacleAndGem();
        else row.CreateWithoutObstacle();
        distanceZ += constdistanceZ;
    }
    
}
