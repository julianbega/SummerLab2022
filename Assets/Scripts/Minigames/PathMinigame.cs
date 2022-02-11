using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMinigame : MonoBehaviour
{    
    private float screenWith = Screen.width;
    private float screenHeight = Screen.height;
    private float shortestSide;

    public int rowsAndColumns;
    private float cubeSize;
    public GameObject cubePrimitive;
    public float distance;
    GameObject test;
    Vector3 auxi;
    //public Vector2 test;
    void Start()
    {
        
        if (screenHeight > screenWith)
            shortestSide = screenWith;
        else
            shortestSide = screenHeight;

        cubeSize = shortestSide / (rowsAndColumns + 2);

        
        auxi.x = (cubeSize);
        auxi.z = Camera.main.nearClipPlane + distance;
        auxi.y = ((shortestSide / 2) - cubeSize);
        test = Instantiate(cubePrimitive, Camera.main.ScreenToWorldPoint(auxi), Quaternion.identity, null);

        Vector3 firstCubePos = new Vector3((-(shortestSide/2)+ cubeSize), -10, ((shortestSide / 2) - cubeSize));
        Vector3 screenCubePos = Camera.main.ScreenToWorldPoint(firstCubePos);
        //Instantiate(cubePrimitive, screenCubePos, Quaternion.identity);
    }

    void Update()
    {
        auxi.z = Camera.main.nearClipPlane + distance;
        test.transform.position = Camera.main.ScreenToWorldPoint(auxi);
        test.transform.LookAt(Camera.main.transform);
        //Debug.Log(Camera.main.ScreenToWorldPoint(test));
    }
}
