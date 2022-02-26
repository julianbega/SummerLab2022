using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class FoodPref : MonoBehaviour
{

    public static Action foodEnteredTheBasket;
    bool die;
    public float speed;
    Vector3 pos;
    private void Start()
    {
        die = false;
        pos = this.transform.position;
    }
    private void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (speed * Time.deltaTime), this.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HorizontalWall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Box" && die == true)
        {
            die = false;
            foodEnteredTheBasket?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
