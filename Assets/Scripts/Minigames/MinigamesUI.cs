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
    public GameObject victoryPanel;
    public GameObject defeatPanel;
    public TextMeshProUGUI time;
    public TextMeshProUGUI target;
    public TextMeshProUGUI targetsLeft;
    public MemotestManager mm;


    public void hidePanel()
    {
        dificultyPanel.SetActive(false);
    }

    public void Update()
    {
        time.text = "Time: " + Mathf.Round(mm.timer * 100.0f) * 0.01f;
        if(mm.started == false)
        {
            target.text = "Target = ???";
        }
        else
        { 
        target.text = "Target = " + mm.target.GetComponent<MemotestBox>().tipo.ToString();
        }
        targetsLeft.text = "Targets left = " + mm.targetCount;

        if(mm.victoy)
        {
            victoryPanel.SetActive(true);
        }
        if(mm.defeat)
        {
            defeatPanel.SetActive(true);
        }
    }
    public void HideVictoryPanel()
    {
        Debug.Log(" hide Victory");
        victoryPanel.SetActive(false);
    }
    public void HideDefeatPanel()
    {
        Debug.Log(" hide defeat");
        defeatPanel.SetActive(false);
    }
}
