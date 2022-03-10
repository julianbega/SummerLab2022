using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemotestManager : MonoBehaviour
{
    public enum type
    {
        PostreBox = 0, VegetalBox, FrutaBox, CarneBox
    }

    public List<MemotestLevelSO> levels;
    public MemotestLevelSO currentLevel;
    public GameObject target;

    public dif dificulty;
    private int targetType;


    public List<GameObject> notTargets;
    public int targetCount;


    public GameObject carnePrefab;
    public GameObject frutaPrefab;
    public GameObject vegetalPrefab;
    public GameObject postrePrefab;

    public float Radius = 1;
    public float timer;
    public bool started;
    public bool victoy;
    public bool defeat;

    private GameManager gm;
    private bool gameEnded;

    void Start()
    {
        gameEnded = false;
        gm = FindObjectOfType<GameManager>();
        victoy = false;
        defeat = false;
        started = false;
        timer = -100;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0 && !started)
            {
                if (currentLevel != null)
                {
                    timer = currentLevel.timeToPlay;
                    startMoving();
                }
            }
            if (timer <= 0 && started == true)
            {
                gameEnded = true;

                Defeat();
            }
            if (targetCount <= 0 && started == true)
            {
                gm.ADNCoin += currentLevel.priceQuantity;
                gameEnded = true;
                Victory();
            }
        }

    }

    void InitLevel()
    {
        gameEnded = false;
        targetCount = currentLevel.TargetCuantity;
        timer = currentLevel.timeToMemorice;
        targetType = Random.Range(0, 3);
        switch (targetType)
        {
            case 0:
                target = postrePrefab;
                notTargets.Add(carnePrefab);
                notTargets.Add(frutaPrefab);
                notTargets.Add(vegetalPrefab);
                break;
            case 1:
                target = vegetalPrefab;
                notTargets.Add(carnePrefab);
                notTargets.Add(frutaPrefab);
                notTargets.Add(postrePrefab);
                break;
            case 2:
                target = frutaPrefab;
                notTargets.Add(carnePrefab);
                notTargets.Add(postrePrefab);
                notTargets.Add(vegetalPrefab);
                break;
            case 3:
                target = carnePrefab;
                notTargets.Add(postrePrefab);
                notTargets.Add(frutaPrefab);
                notTargets.Add(vegetalPrefab);
                break;

            default:
                break;
        }


        for (int i = 0; i < currentLevel.TargetCuantity; i++)
        {
            Vector3 auxSpawnPos = Random.insideUnitCircle * Radius;
            Vector3 spawnPos = new Vector3(auxSpawnPos.x, auxSpawnPos.y, 10.5f);
            Instantiate(target, spawnPos, Quaternion.identity);
        }
        for (int i = 0; i < currentLevel.notTargetCuantity; i++)
        {
            Vector3 auxSpawnPos = Random.insideUnitCircle * Radius;
            Vector3 spawnPos = new Vector3(auxSpawnPos.x, auxSpawnPos.y, 10.5f);
            Instantiate(notTargets[Random.Range(0, (notTargets.Count))], spawnPos, Quaternion.identity);
        }
    }  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

    public void setDificulty(int id)
    {
        currentLevel = levels[id];
        InitLevel();
    }
    void startMoving()
    {
        started = true;
    }

    public void Defeat()
    {
        StartCoroutine("WaitDefeat");
    }
    public void Victory()
    {
        //AudioManager.amInstance.music.PlayOneShot(AudioManager.amInstance.sfx[4]);
        StartCoroutine("WaitVictory");
    }

    IEnumerator WaitVictory()
    {
        yield return new WaitForSeconds(2f);
        
        victoy = true;
        started = false;
        timer = -100;
        AudioManager.amInstance.SFX.PlayOneShot(AudioManager.amInstance.sfxList[3]);
    }
    IEnumerator WaitDefeat()
    {
        yield return new WaitForSeconds(2f);
        
        defeat = true;
        started = false;
        timer = -100;
    }

    public void Restart()
    {
        victoy = false;
        defeat = false;
        started = false;
        notTargets.Clear();
        target = null;
        InitLevel();
    }
}
