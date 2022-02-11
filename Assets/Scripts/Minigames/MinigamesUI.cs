using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;


public class MinigamesUI : MonoBehaviour
{
    public GameObject dificultyPanel;
    public TextMeshProUGUI time;
    public MemotestManager mm;


    public void hidePanel()
    {
        dificultyPanel.SetActive(false);
    }

    public void Update()
    {
        time.text = "Time: " + Mathf.Round(mm.timer * 100.0f) * 0.01f;
    }
}
