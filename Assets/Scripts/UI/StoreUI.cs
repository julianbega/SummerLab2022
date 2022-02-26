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
    private bool hasEggSelected;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        hasEggSelected = false;
        money.text = ":" + gm.ADNCoin;
        if (sm.selectedEgg != null)
        {
            hasEggSelected = true;
            eggPrice.text = "Price: " + sm.selectedEgg.price;
            eggName.text = "" + sm.selectedEgg.name;
        }

        EggRandomizer.NoMoney += MoneyBlink;
    }
    private void OnDisable()
    {
        EggRandomizer.NoMoney -= MoneyBlink;
    }
    private void Update()
    {
        if (!hasEggSelected)
        {
            if (sm.selectedEgg != null)
            {
                hasEggSelected = true;
                eggPrice.text = "Price: " + sm.selectedEgg.price;
                eggName.text = "" + sm.selectedEgg.name;
            }
        }
    }
    public void ChangeEgg()
    {
        hasEggSelected = true;
        eggPrice.text = "Price: " + sm.selectedEgg.price;
        eggName.text = "" + sm.selectedEgg.name;
    }
    public void UpdateMoney()
    {
        money.text = ":" + gm.ADNCoin;
    }

    public void MoneyBlink()
    {
        money.color = Color.red;
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(0.2f);
        money.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        money.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        money.color = Color.white;
    }
}
