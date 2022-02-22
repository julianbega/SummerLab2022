using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class Characters : ScriptableObject
{
    public string characterName;
    public GameObject head;
    public GameObject body;
    public GameObject legs;
    public Material headMat;
    public Material bodyMat;
    public Material legsMat;
}
