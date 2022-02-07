using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggRandomizer : MonoBehaviour
{
    public GameManager gm;
    public Egg eggSelected;
    float selectedNumber;
    public GameObject selectedBody;
    public GameObject selectedHead;
    public GameObject selectedLeg;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void randomize()
    {
        RandomizeHead();
        RandomizeBody();
        RandomizeLegs();


        Characters newCharacter = new Characters();
        newCharacter.characterName = "nombre";
        newCharacter.head = selectedHead;
        newCharacter.body = selectedBody;
        newCharacter.legs = selectedLeg;

        gm.ownedCharacters.Add(newCharacter);
    }

    public void RandomizeHead()
    {
        selectedNumber = Random.Range(0.00f, 100.00f);
        Debug.Log("Head " + selectedNumber);
        for (int j = 0; j < eggSelected.head.Count; j++)
        {
            Debug.Log("SelectedHead chance " + eggSelected.head[j].chance);
            if (eggSelected.head[j].chance >= selectedNumber)
            {
                selectedHead = eggSelected.head[j].part;
                return;
            }
            else
            {
                selectedNumber -= eggSelected.head[j].chance;
            }
        }
    }

    public void RandomizeBody()
    {
        selectedNumber = Random.Range(0.00f, 100.00f);
        Debug.Log("Body " + selectedNumber);
        for (int i = 0; i < eggSelected.body.Count; i++)
        {
            Debug.Log("SelectedBody chance " + eggSelected.body[i].chance);
            if (eggSelected.body[i].chance >= selectedNumber)
            {
                selectedBody = eggSelected.body[i].part;
                return;
            }
            else
            {
                selectedNumber -= eggSelected.body[i].chance;
            }
        }
    }

    public void RandomizeLegs()
    {
        selectedNumber = Random.Range(0.00f, 100.00f);
        Debug.Log("Legs " + selectedNumber);
        for (int l = 0; l < eggSelected.legs.Count; l++)
        {
            Debug.Log("SelectedLegs chance " + eggSelected.body[l].chance);
            if (eggSelected.legs[l].chance >= selectedNumber)
            {
                selectedLeg = eggSelected.legs[l].part;
                return;
            }
            else
            {
                selectedNumber -= eggSelected.legs[l].chance;
            }
        }
    }
}
