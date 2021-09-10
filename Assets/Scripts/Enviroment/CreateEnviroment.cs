using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creating an environment
/// </summary>
public class CreateEnviroment : MonoBehaviour
{
    [SerializeField] ColorPath colorPath;
    [SerializeField] int countPart;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform finishPoint;

    public float pathPartLenth { get; set; }
    public float pathPartLenthStart { get; set; }
    void Awake()
    {
        pathPartLenth = transform.lossyScale.z/countPart;
        pathPartLenthStart = pathPartLenth;
        for (int i = 0; i < countPart; i++)
        {
            CreateColorPaths();
            startPoint.position = new Vector3(startPoint.position.x, startPoint.position.y, startPoint.position.z + pathPartLenth);
        }
    }

    /// <summary>
    /// Create a segment with an environment
    /// </summary>
    void CreateColorPaths()
    {
        ColorPath path = Instantiate(colorPath, startPoint.position, Quaternion.identity);        
    }




}
