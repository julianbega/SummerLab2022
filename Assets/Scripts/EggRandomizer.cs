using UnityEngine;
using System;
using System.Collections;

public class EggRandomizer : MonoBehaviour
{
    public GameManager gm;
    public Egg eggSelected;
    float selectedNumber;
    float matSelectedNumber;
    public GameObject selectedBody;
    public GameObject selectedHead;
    public GameObject selectedLeg;
    public Material selectedBodyMat;
    public Material selectedHeadMat;
    public Material selectedLegMat;
    public ShopManager SM;
    static public event Action NoMoney;

    private void Start()
    {
        SM = FindObjectOfType<ShopManager>();
        gm = FindObjectOfType<GameManager>();
    }
    public void randomize()
    {
        if (gm.ADNCoin >= SM.selectedEgg.price)
        {
            AudioManager.amInstance.SFX.PlayOneShot(AudioManager.amInstance.sfxList[0]);
            gm.ADNCoin -= SM.selectedEgg.price;



        RandomizeHead();
        RandomizeBody();
        RandomizeLegs();


        Characters newCharacter = new Characters();
        newCharacter.characterName = "nombre";
        newCharacter.head = selectedHead;
        newCharacter.body = selectedBody;
        newCharacter.legs = selectedLeg;
        newCharacter.headMat = selectedHeadMat;
        newCharacter.bodyMat = selectedBodyMat;
        newCharacter.legsMat = selectedLegMat;

        gm.ownedCharacters.Add(newCharacter);
        }
        else
        {
            // sonido de que falta plata
            NoMoney?.Invoke();
        }
    }

    public void RandomizeHead()
    {
        selectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);
        matSelectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);

        for (int j = 0; j < eggSelected.head.Count; j++)
        {
            if (eggSelected.head[j].chance >= selectedNumber)
            {
                selectedHead = eggSelected.head[j].part;
                
                for (int k = 0; k < eggSelected.head[j].materials.Count; k++)
                {
                    if(eggSelected.head[j].materials[k].chance >= matSelectedNumber)
                    {
                        selectedHeadMat = eggSelected.head[j].materials[k].mat;
                        return;
                    }
                    else
                    {
                        matSelectedNumber -= eggSelected.head[j].materials[k].chance;
                    }
                }
                
            }
            else
            {
                selectedNumber -= eggSelected.head[j].chance;
            }
        }


    }

    public void RandomizeBody()
    {
        selectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);
        matSelectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);

        for (int i = 0; i < eggSelected.body.Count; i++)
        {
            if (eggSelected.body[i].chance >= selectedNumber)
            {
                selectedBody = eggSelected.body[i].part;
                for (int m = 0; m < eggSelected.body[i].materials.Count; m++)
                {
                    if (eggSelected.body[i].materials[m].chance >= matSelectedNumber)
                    {
                        selectedBodyMat = eggSelected.body[i].materials[m].mat;
                        return;
                    }
                    else
                    {
                        matSelectedNumber -= eggSelected.body[i].materials[m].chance;
                    }
                }
            }
            else
            {
                selectedNumber -= eggSelected.body[i].chance;
            }
        }
    }

    public void RandomizeLegs()
    {
        selectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);
        matSelectedNumber = UnityEngine.Random.Range(0.00f, 100.00f);

        for (int l = 0; l < eggSelected.legs.Count; l++)
        {
            if (eggSelected.legs[l].chance >= selectedNumber)
            {
                selectedLeg = eggSelected.legs[l].part;
                for (int n = 0; n < eggSelected.legs[l].materials.Count; n++)
                {
                    if (eggSelected.legs[l].materials[n].chance >= matSelectedNumber)
                    {
                        selectedLegMat = eggSelected.legs[l].materials[n].mat;
                        return;
                    }
                    else
                    {
                        matSelectedNumber -= eggSelected.legs[l].materials[n].chance;
                    }
                }
            }
            else
            {
                selectedNumber -= eggSelected.legs[l].chance;
            }
        }
    }
}
