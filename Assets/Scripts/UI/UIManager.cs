using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject minigamesPanel;
    public GameObject mainMenuPanel;

    public TextMeshProUGUI money;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        money.text = ":  :" + gm.ADNCoin;
    }

    public void showMenu()
    {
        mainMenuPanel.SetActive(true);
        minigamesPanel.SetActive(false);
    }
    public void hideMenu()
    {
        mainMenuPanel.SetActive(false);
        minigamesPanel.SetActive(true);
    }

}
