using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<Egg> EggsToSell;
    private Egg selectedEgg;
    public GameObject egg;
    public int index;
    Vector3 eggPosition;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        selectedEgg = EggsToSell[index];
        egg = selectedEgg.EggPrefab;
        eggPosition = new Vector3(0.01f, 0.05f, 0.05f);
        egg = Instantiate(selectedEgg.EggPrefab, eggPosition, Quaternion.identity); 
    }
    public void ChangeNextEgg()
    {
        Destroy(egg.gameObject);
        if (index < EggsToSell.Count-1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        selectedEgg = EggsToSell[index];
        egg = Instantiate(selectedEgg.EggPrefab, eggPosition, Quaternion.identity);
    }

    public void ChangePreviousEgg()
    {
        Destroy(egg.gameObject);
        if (index > 0)
        {
            index--;
        }
        else 
        {
            index = EggsToSell.Count - 1;
        }
        selectedEgg = EggsToSell[index];
        egg = Instantiate(selectedEgg.EggPrefab, eggPosition, Quaternion.identity);
    }
}
