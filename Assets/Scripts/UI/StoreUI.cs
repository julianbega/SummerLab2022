using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class StoreUI : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI eggName;
    public TextMeshProUGUI eggPrice;
    private GameManager gm;
    public ShopManager sm;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        money.text = ":" + +gm.ADNCoin;
    }

   public void UpdateMoney()
    {
        money.text = ":" + +gm.ADNCoin;
    }
}
