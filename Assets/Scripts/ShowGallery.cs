using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGallery : MonoBehaviour
{
    public GameManager gm;
    public int index;
    public Characters defaultCharacter;
    Vector3 charGalleryPos;
    Vector3 charGalleryScale;

    GameObject characterHead;
    GameObject characterBody;
    GameObject characterLegs;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        charGalleryPos = new Vector3(0, -0.056f, -0.248f);
        charGalleryScale = new Vector3(2.5f, 2.5f, 2.5f);
        index = 0;
        if (gm.selectedCharacter != null)
        {
            characterHead = Instantiate(gm.selectedCharacter.head, charGalleryPos, Quaternion.identity);
            characterBody = Instantiate(gm.selectedCharacter.body, charGalleryPos, Quaternion.identity);
            characterLegs = Instantiate(gm.selectedCharacter.legs, charGalleryPos, Quaternion.identity);
        }
        else if (gm.ownedCharacters[index] != null)
        {
            characterHead = Instantiate(gm.ownedCharacters[index].head, charGalleryPos, Quaternion.identity);
            characterBody = Instantiate(gm.ownedCharacters[index].body, charGalleryPos, Quaternion.identity);
            characterLegs = Instantiate(gm.ownedCharacters[index].legs, charGalleryPos, Quaternion.identity);

        }
        else 
        {
            characterHead = Instantiate(defaultCharacter.head, charGalleryPos, Quaternion.identity);
            characterBody = Instantiate(defaultCharacter.body, charGalleryPos, Quaternion.identity);
            characterLegs = Instantiate(defaultCharacter.legs, charGalleryPos, Quaternion.identity);
        }

        characterHead.transform.localScale = charGalleryScale;
        characterBody.transform.localScale = charGalleryScale;
        characterLegs.transform.localScale = charGalleryScale;
    }

    public void NextCharacter()
    {
        if(gm.ownedCharacters.Count-1 == index)
        {
            index = 0;
        }
        else
        {
            index++;
        }        
        ChangeShowedCharacter();
    }
    public void PreviousCharacter()
    {
        if (index == 0)
        {
            index = gm.ownedCharacters.Count-1;
        }
        else
        {
            index--;
        }
        
        ChangeShowedCharacter();
    }
    void ChangeShowedCharacter()
    {
        Destroy(characterHead);
        Destroy(characterBody);
        Destroy(characterLegs);

        characterHead = Instantiate(gm.ownedCharacters[index].head, charGalleryPos, Quaternion.identity);        
        characterBody = Instantiate(gm.ownedCharacters[index].body, charGalleryPos, Quaternion.identity);        
        characterLegs = Instantiate(gm.ownedCharacters[index].legs, charGalleryPos, Quaternion.identity);
        characterHead.transform.localScale = charGalleryScale;
        characterBody.transform.localScale = charGalleryScale;
        characterLegs.transform.localScale = charGalleryScale;
    }

    void ShowFirstCharacter()
    {
        index = 0;
        ChangeShowedCharacter();
    }

    public void SellCharacter()
    {
        if (gm.ownedCharacters.Count >= 2)
        {
            gm.ownedCharacters.RemoveAt(index);
            gm.ADNCoin += 100;
            ShowFirstCharacter();
        }
    }
    public void SelectCharacter()
    {
        gm.selectedCharacter.head = characterHead;
        gm.selectedCharacter.body = characterBody;
        gm.selectedCharacter.legs = characterLegs;
    }
}
