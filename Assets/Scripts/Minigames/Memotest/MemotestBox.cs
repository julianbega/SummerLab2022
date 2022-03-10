using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemotestBox : MonoBehaviour
{
    public enum type
    {
        Postre, Vegetal,Fruta,Carne
    }

    private bool alreadyStart;
    public type tipo;
    public Vector3 movingDirection;
    private MemotestManager mm;
    private bool clicked;
    private string targetType;
    private bool alreadyDestroyed;
    public Sprite imagen;
    private void Start()
    {
        mm = FindObjectOfType<MemotestManager>();
        movingDirection.x = Random.Range(-mm.currentLevel.maxSpeed, mm.currentLevel.maxSpeed);
        movingDirection.y = Random.Range(-mm.currentLevel.maxSpeed, mm.currentLevel.maxSpeed);
        if(movingDirection.x >= 0 && movingDirection.x< mm.currentLevel.minSpeed)
        {
            movingDirection.x = mm.currentLevel.minSpeed;
        }
        if (movingDirection.x < 0 && movingDirection.x > -mm.currentLevel.minSpeed)
        {
            movingDirection.x = -mm.currentLevel.minSpeed;
        }
        alreadyStart = false;
        alreadyDestroyed = false;
        clicked = false;
        targetType = mm.target.GetComponent<MemotestBox>().tipo.ToString();
    }
    void Update()
    {
        if (!clicked)
        {
            if (mm.started)
            {
                alreadyStart = true;
                this.transform.position += (movingDirection * Time.deltaTime);
            }
            if (alreadyStart)
            {
                alreadyStart = false;
                this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(0, 180, 0, 0));
            }
        }
        if(mm.defeat || mm.victoy)
        {
            Destroy(this.gameObject);
        }
    }

    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            clicked = true;
            this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(0, 180, 0, 0));
            Debug.Log("target= " + targetType + " this = " + tipo.ToString());
            if (targetType == tipo.ToString())
            {
                Debug.Log("true");
                if (!alreadyDestroyed) 
                {
                    mm.targetCount--;
                }
                alreadyDestroyed = true;
                this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(0, 0, 0, 0));
                StartCoroutine("DestroyBox");
                AudioManager.amInstance.SFX.PlayOneShot(AudioManager.amInstance.sfxList[2]);
            }
            else
            {
                this.transform.SetPositionAndRotation(this.transform.position, new Quaternion(0, 0, 0, 0));
                defeat();
            }
        }
    }

    public void defeat()
    {
        mm.timer = 0f;

      //  Debug.Log("defeated");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VerticalWall")
        {
           movingDirection.x = -movingDirection.x;
        }

        if (other.tag == "HorizontalWall")
        {
           movingDirection.y = -movingDirection.y;
        }
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
