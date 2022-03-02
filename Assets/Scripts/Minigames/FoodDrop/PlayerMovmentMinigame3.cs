using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentMinigame3 : MonoBehaviour
{
    public float playerSpeed;
    public GameObject canasta;
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Vector3 mousePos = Input.mousePosition;
            if(mousePos.x <= (Screen.width/2) )
            {
                if (canasta.transform.position.x <= 1)
                {
                    canasta.transform.position = new Vector3(canasta.transform.position.x + (playerSpeed * Time.deltaTime), canasta.transform.position.y, canasta.transform.position.z);
                    character.transform.position = new Vector3(character.transform.position.x + (playerSpeed * Time.deltaTime), character.transform.position.y, character.transform.position.z);
                }
            }
            else
            {
                if (canasta.transform.position.x >= -0.95)
                {
                    canasta.transform.position = new Vector3(canasta.transform.position.x - (playerSpeed * Time.deltaTime), canasta.transform.position.y, canasta.transform.position.z);
                    character.transform.position = new Vector3(character.transform.position.x - (playerSpeed * Time.deltaTime), character.transform.position.y, character.transform.position.z);
                }
            }

        }

    }


       
}
