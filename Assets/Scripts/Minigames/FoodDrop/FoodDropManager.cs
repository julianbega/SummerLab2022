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

    public GameObject bomb;

    public float timeBetweenSpawns;

    public float timeBetweenBombSpawns;
    public float bombFallSpeed;
    public float foodFallSpeed;
    float spawnTime;
    float bombSpawnTime;
    public GameObject character;

    public List<GameObject> foodPrefabs;

    void Start()
    {
        spawnTime = timeBetweenSpawns;
        bombSpawnTime = timeBetweenBombSpawns;
        charStartingPos = new Vector3(0, 0.1f, 0f);
        charGalleryScale = new Vector3(2.5f, 2.5f, 2.5f);
        gm = FindObjectOfType<GameManager>();

        characterHead = Instantiate(gm.selectedCharacter.head, charStartingPos, Quaternion.identity);
        characterBody = Instantiate(gm.selectedCharacter.body, charStartingPos, Quaternion.identity);
        characterLegs = Instantiate(gm.selectedCharacter.legs, charStartingPos, Quaternion.identity);
        characterHead.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.headMat;
        characterHead.GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        characterBody.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.bodyMat;
        characterBody.GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        characterLegs.GetComponentInChildren<MeshRenderer>().material = gm.selectedCharacter.legsMat;
        characterLegs.GetComponentInChildren<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        characterHead.transform.localScale = charGalleryScale;
        characterBody.transform.localScale = charGalleryScale;
        characterLegs.transform.localScale = charGalleryScale;
        characterHead.transform.SetParent(character.transform);
        characterBody.transform.SetParent(character.transform);
        characterLegs.transform.SetParent(character.transform);

        FoodPref.foodEnteredTheBasket += GainPoints;
        Bomb.bombHit += LoseHP;
    }
    private void OnDisable()
    {
        FoodPref.foodEnteredTheBasket -= GainPoints;
        Bomb.bombHit -= LoseHP;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        bombSpawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = timeBetweenSpawns;
            SpawnRandomFood();
        }
        if (bombSpawnTime <= 0)
        {
            bombSpawnTime = timeBetweenBombSpawns;
            SpawnBomb();
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

    void SpawnBomb()
    {
        GameObject spawneBomb;
        float randX = Random.Range(XLimits[0], XLimits[1]);
        float randy = Random.Range(1.2f, 1.5f);
        Vector3 spawnPos = new Vector3(randX, randy, 0);
        int selectedFoodPref = Random.Range(0, foodPrefabs.Count);
        spawneBomb = Instantiate(bomb, spawnPos, Quaternion.identity);
        bomb.GetComponent<Bomb>().speed = foodFallSpeed;
    }

    void GainPoints()
    {

    }

    void LoseHP()
    { }

}
