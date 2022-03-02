using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class FoodPref : MonoBehaviour
{

    public static Action foodEnteredTheBasket;
    public bool die;
    public float speed;
    private void Start()
    {
        FoodDropManager.destroyAllGo += DeleteThis;
        die = false;
    }
    private void OnDisable()
    {
        FoodDropManager.destroyAllGo -= DeleteThis;
    }
    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (speed * Time.deltaTime), this.transform.position.z);
       
        if (this.transform.position.y <= 0)
        {           
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HorizontalWall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Box" && die == false)
        {
            die = true;
            foodEnteredTheBasket?.Invoke();
            Destroy(this.gameObject);
        }
    }

    void DeleteThis()
    {
        Destroy(this.gameObject);
    }
}
