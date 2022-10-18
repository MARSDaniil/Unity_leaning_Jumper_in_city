using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float xCoordinatsToDelete = -14;
    private playerController playerControllerScript;
   // private bool isItPlane = false;

    private Vector3 coordinatsToDelete;
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
        coordinatsToDelete = new Vector3(xCoordinatsToDelete, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < coordinatsToDelete.x)
        {
            Destroy(gameObject);
        }
        if (playerControllerScript.planeAirCrash == true && transform.position.y > 2)
        {
            Destroy(gameObject);
        }
    }

 

    
}


