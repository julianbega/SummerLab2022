using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;


public class UI_Minigame3 : MonoBehaviour
{
    private FoodDropManager fdm;

    public TextMeshProUGUI lives;
    public TextMeshProUGUI points;
    public GameObject pausePanel;
    public GameObject defeatPanel;

    public TextMeshProUGUI moneyEarned;

    // Start is called before the first frame update
    void Start()
    {
        fdm = FindObjectOfType<FoodDropManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "" + fdm.lives;
        points.text = "" + fdm.points;
        moneyEarned.text = "ADNCoins earned: " + fdm.points;
        if (fdm.GetDefeat())
        {
            ShowDefeat();
        }
    }

    public void ShowPause()
    {
        pausePanel.SetActive(true);
    }
    public void HidePause()
    {
        pausePanel.SetActive(false);
    }

    void ShowDefeat()
    {
        defeatPanel.SetActive(true);
    }
    public void HideDefeat()
    {
        defeatPanel.SetActive(false);
    }
}
