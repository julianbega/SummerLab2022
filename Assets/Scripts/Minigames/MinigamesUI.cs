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
    public GameObject HowToPlay;
    public TextMeshProUGUI time;
    public TextMeshProUGUI target;
    public TextMeshProUGUI targetsLeft;
    public TextMeshProUGUI money;
    public TextMeshProUGUI moneyGained;
    public MemotestManager mm;
    public Image foodIcon;
    public Sprite secret;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        money.text = ":  :" + + gm.ADNCoin;
    }

    public void hidePanel()
    {
        dificultyPanel.SetActive(false);
    }

    public void Update()
    {
        time.text = "" + Mathf.Round(mm.timer * 100.0f) * 0.01f;
        if(mm.started == false)
        {
            target.text = "Target = ???";
            foodIcon.sprite = secret;
        }
        else
        { 
        target.text = "" + mm.target.GetComponent<MemotestBox>().tipo.ToString();
            foodIcon.sprite = mm.target.GetComponent<MemotestBox>().imagen;
        }
        targetsLeft.text = "" + mm.targetCount;

        if(mm.victoy)
        {
            victoryPanel.SetActive(true);
            money.text = ":  :" + + gm.ADNCoin;
            moneyGained.text = "" + mm.currentLevel.priceQuantity;
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

    public void OpenHowToPlay()
    {
        HowToPlay.SetActive(true);
    }
    public void CloseHowToPlay()
    {
        HowToPlay.SetActive(false);
    }
}
