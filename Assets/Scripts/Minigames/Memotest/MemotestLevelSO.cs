using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum dif
{
    facil, normal, dificil
}
[CreateAssetMenu]
public class MemotestLevelSO : ScriptableObject
{    
    public dif dificulty;
    public int notTargetCuantity;
    public int TargetCuantity;
    public float minSpeed;
    public float maxSpeed;
    public float timeToMemorice;
    public float timeToPlay;
    public int priceQuantity;

}


