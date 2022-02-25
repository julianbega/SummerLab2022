using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Characters selectedCharacter;
    public List<Characters> ownedCharacters;

    public int ADNCoin;

    public List<Material> Materials;
    public List<GameObject> Models;

    Characters loadCharacter;
    static public GameManager instanceGameManager;

    private int firstTime;
    static public GameManager instance { get { return instanceGameManager; } }
    

    private void Awake()
    {
        if (instanceGameManager != null && instanceGameManager != this)
            Destroy(this.gameObject);
        else
            instanceGameManager = this;

        SceneController.DontDestroyOnLoad(this);
    }
    void Start()
    {
        Load();
    }
    public void OnDisable()
    {
        Save();
    }
    public void AddMoney()
    {
        ADNCoin += 100;
    }

    public void Load()
    {
        
        firstTime = PlayerPrefs.GetInt("FirstTime");
        ADNCoin = PlayerPrefs.GetInt("ANDCoings");
        /*
                Debug.Log("SelectedHeadIndex" + PlayerPrefs.GetInt("SelectedCharacterHead") );
                Debug.Log("SelectedBodyIndex" + PlayerPrefs.GetInt("SelectedCharacterBody"));
                Debug.Log("SelectedLegsIndex" + PlayerPrefs.GetInt("SelectedCharacterLegs"));*/

        Characters newCharacter = new Characters();
        newCharacter.characterName = "nombre";
        newCharacter.head = Models[PlayerPrefs.GetInt("SelectedCharacterHead")];
        newCharacter.body = Models[PlayerPrefs.GetInt("SelectedCharacterBody")];
        newCharacter.legs = Models[PlayerPrefs.GetInt("SelectedCharacterLegs")]; 
        newCharacter.headMat = Materials[PlayerPrefs.GetInt("SelectedCharacterHeadMat")];
        newCharacter.bodyMat = Materials[PlayerPrefs.GetInt("SelectedCharacterBodyMat")];
        newCharacter.legsMat = Materials[PlayerPrefs.GetInt("SelectedCharacterLegsMat")];
        selectedCharacter = newCharacter;

        for (int i = 0; i < PlayerPrefs.GetInt("ownedCharactesQuantity"); i++)
        {
            LoadOwnedCharacter(i);
        }

    }

    void LoadOwnedCharacter(int index)
    {
        Characters newCharacter = new Characters();
        newCharacter.characterName = "nombre";
        newCharacter.head = Models[PlayerPrefs.GetInt("OwnedCharacterHead" + index)];
        newCharacter.body = Models[PlayerPrefs.GetInt("OwnedCharacterBody" + index)];
        newCharacter.legs = Models[PlayerPrefs.GetInt("OwnedCharacterLegs" + index)];
        newCharacter.headMat = Materials[PlayerPrefs.GetInt("OwnedCharacterHeadMat" + index)];
        newCharacter.bodyMat = Materials[PlayerPrefs.GetInt("OwnedCharacterBodyMat" + index)];
        newCharacter.legsMat = Materials[PlayerPrefs.GetInt("OwnedCharacterLegsMat" + index)];
        ownedCharacters.Add(newCharacter);

    }
    public void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("ANDCoings", ADNCoin);
        PlayerPrefs.SetInt("ownedCharactesQuantity", ownedCharacters.Count);
        SaveSelectedCharacter();
        for (int i = 0; i < ownedCharacters.Count; i++)
        {
            SaveCharacter(i);
        }
    }

    void SaveSelectedCharacter()
    {
        int selectedHeadId = 0;
        int selectedBodyId = 0;
        int selectedLegsId = 0;
        for (int i = 0; i < Models.Count; i++)
        {
            if (Models[i] == selectedCharacter.head)
            {
                selectedHeadId = i;
            }
            if (Models[i] == selectedCharacter.body)
            {
                selectedBodyId = i;
            }
            if (Models[i] == selectedCharacter.legs)
            {
                selectedLegsId = i;
            }
        }
        PlayerPrefs.SetInt("SelectedCharacterHead", selectedHeadId);
        PlayerPrefs.SetInt("SelectedCharacterBody", selectedBodyId);
        PlayerPrefs.SetInt("SelectedCharacterLegs", selectedLegsId);

        int selectedHeadMatId = 0;
        int selectedBodyMatId = 0;
        int selectedLegsMatId = 0;
        for (int i = 0; i < Materials.Count; i++)
        {
            if (Materials[i] == selectedCharacter.headMat)
            {
                selectedHeadMatId = i;
            }
            if (Materials[i] == selectedCharacter.bodyMat)
            {
                selectedBodyMatId = i;
            }
            if (Materials[i] == selectedCharacter.legsMat)
            {
                selectedLegsMatId = i;
            }
        }
        PlayerPrefs.SetInt("SelectedCharacterHeadMat", selectedHeadMatId);
        PlayerPrefs.SetInt("SelectedCharacterBodyMat", selectedBodyMatId);
        PlayerPrefs.SetInt("SelectedCharacterLegsMat", selectedLegsMatId);

    }

    void SaveCharacter(int index)
    {
        int HeadId = 0;
        int BodyId = 0;
        int LegsId = 0;
        for (int i = 0; i < Models.Count; i++)
        {
            if (Models[i] == ownedCharacters[i].head)
            {
                HeadId = i;
            }
            if (Models[i] == ownedCharacters[i].body)
            {
                BodyId = i;
            }
            if (Models[i] == ownedCharacters[i].legs)
            {
                LegsId = i;
            }
        }
        PlayerPrefs.SetInt("OwnedCharacterHead" + index, HeadId);
        PlayerPrefs.SetInt("OwnedCharacterBody" + index, BodyId);
        PlayerPrefs.SetInt("OwnedCharacterLegs" + index, LegsId);

        int HeadMatId = 0;
        int BodyMatId = 0;
        int LegsMatId = 0;
        for (int i = 0; i < Materials.Count; i++)
        {
            if (Materials[i] == ownedCharacters[i].headMat)
            {
                HeadMatId = i;
            }
            if (Materials[i] == ownedCharacters[i].bodyMat)
            {
                BodyMatId = i;
            }
            if (Materials[i] == ownedCharacters[i].legsMat)
            {
                LegsMatId = i;
            }
        }
        PlayerPrefs.SetInt("OwnedCharacterHeadMat" + index, HeadMatId);
        PlayerPrefs.SetInt("OwnedCharacterBodyMat" + index, BodyMatId);
        PlayerPrefs.SetInt("OwnedCharacterLegsMat" + index, LegsMatId);


    }
    public void restartSave()
    {
        PlayerPrefs.DeleteAll();
    }



}
