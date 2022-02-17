using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class partChance
{
    public GameObject part;
    public float chance;
}
[CreateAssetMenu]
public class Egg : ScriptableObject
{
    public GameObject EggPrefab;
    public GameObject BrokenEggPrefab;
    public GameObject AlmostBrokenEggPrefab;
    public int price;
    public List<partChance> head;
    public List<partChance> body;
    public List<partChance> legs;    
}
