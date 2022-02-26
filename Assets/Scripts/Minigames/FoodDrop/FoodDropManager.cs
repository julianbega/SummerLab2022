using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropManager : MonoBehaviour
{
    public GameManager gm;
    Vector2 XLimits = new Vector2(0.9f, -0.9f);
    GameObject characterHead;
    GameObject characterBody;
    GameObject characterLegs;
    Vector3 charStartingPos;
    Vector3 charGalleryScale;

    public float timeBetweenSpawns;
    public float foodFallSpeed;
    float spawnTime;

    public List<GameObject> foodPrefabs;

    void Start()
    {
        spawnTime = timeBetweenSpawns;
        charStartingPos = new Vector3(0, -0.056f, -0.248f);
        charGalleryScale = new Vector3(2.5f, 2.5f, 2.5f);
        gm = FindObjectOfType<GameManager>();

        characterHead = Instantiate(gm.selectedCharacter.head, charStartingPos, Quaternion.identity);
        characterBody = Instantiate(gm.selectedCharacter.body, charStartingPos, Quaternion.identity);
        characterLegs = Instantiate(gm.selectedCharacter.legs, charStartingPos, Quaternion.identity);
        characterHead.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.headMat;
        characterBody.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.bodyMat;
        characterLegs.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.legsMat;
        characterHead.transform.localScale = charGalleryScale;
        characterBody.transform.localScale = charGalleryScale;
        characterLegs.transform.localScale = charGalleryScale;

        FoodPref.foodEnteredTheBasket += GainPoints;
    }
    private void OnDisable()
    {
        FoodPref.foodEnteredTheBasket -= GainPoints;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = timeBetweenSpawns;
            SpawnRandomFood();
        }
    }

    void SpawnRandomFood()
    {
        GameObject food;
        float randX = Random.Range(XLimits[0], XLimits[1]);
        float randy = Random.Range(1.2f, 1.5f);
        Vector3 spawnPos = new Vector3(randX, randy, 0);
        int selectedFoodPref = Random.Range(0, foodPrefabs.Count);
        food = Instantiate(foodPrefabs[selectedFoodPref], spawnPos, Quaternion.identity);
        food.GetComponent<FoodPref>().speed = foodFallSpeed;
    }

    void GainPoints()
    {

    }

}
