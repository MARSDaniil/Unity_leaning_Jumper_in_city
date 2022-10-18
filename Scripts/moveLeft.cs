using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    //public float time_of_running = 0.1f;
    public float speed;
    public float startSpeed = 10;
  //  private float koeff;
    private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
      //  koeff = playerControllerScript.time_of_running / 100000;

        //speed = speed + koeff;
        speed = playerControllerScript.time_of_running / 1000 + startSpeed;
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        
    }

   
}

