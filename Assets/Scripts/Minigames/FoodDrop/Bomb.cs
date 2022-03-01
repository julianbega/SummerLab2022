using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{

    public static Action bombHit;
    bool die;
    public float speed;
    private void Start()
    {
        die = false;
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
            bombHit?.Invoke();
            Destroy(this.gameObject);
        }
    }

}
