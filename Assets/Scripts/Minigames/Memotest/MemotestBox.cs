using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemotestBox : MonoBehaviour
{
    public enum type
    {
        Postre,Vegetal,Fruta,Carne
    }

    public type tipo;
    public Vector3 movingDirection;
    private MemotestManager mm;
    
    private void Start()
    {
        mm = FindObjectOfType<MemotestManager>();
        movingDirection.x = Random.Range(-mm.currentLevel.maxSpeed, mm.currentLevel.maxSpeed);
        movingDirection.y = Random.Range(-mm.currentLevel.maxSpeed, mm.currentLevel.maxSpeed);

    }
    void Update()
    {
        if(mm.started)
        this.transform.position += (movingDirection * Time.deltaTime);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mm.target.ToString() == tipo.ToString())
            {
                Destroy(this.gameObject);
            }
            else
            {
                defeat();
            }
        }
    }

    public void defeat()
    {
        Debug.Log("defeated");
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

}
