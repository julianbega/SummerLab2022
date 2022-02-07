using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject minigamesPanel;
    public GameObject mainMenuPanel;


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
