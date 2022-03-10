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

    GameObject characterHead;
    GameObject characterBody;
    GameObject characterLegs;

    Vector3 pos;
    Quaternion rot;
    Vector3 scale;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        pos = new Vector3(0f, 0f, -0.1f);
        scale = new Vector3(2.5f, 2.5f, 2.5f);
        rot = new Quaternion(0, 180, 0, 0);
        StartCoroutine("LateStart");
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

    public void ButtonPressed()
    {
        AudioManager.amInstance.music.PlayOneShot(AudioManager.amInstance.sfx[1]);
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.2f);

        money.text = ":  :" + gm.ADNCoin;
        if (gm.selectedCharacter != null)
        {
            characterHead = Instantiate(gm.selectedCharacter.head, pos, rot);
            characterBody = Instantiate(gm.selectedCharacter.body, pos, rot);
            characterLegs = Instantiate(gm.selectedCharacter.legs, pos, rot);
            characterHead.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.headMat;
            characterBody.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.bodyMat;
            characterLegs.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.legsMat;
            characterHead.transform.localScale = scale;
            characterBody.transform.localScale = scale;
            characterLegs.transform.localScale = scale;
        }
    }
}
