using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float time_of_running = 0.1f;
    public float speed = 10;
    private float koeff = 1;
    private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        time_of_running = time_of_running + 1 * Time.deltaTime;
        koeff = time_of_running / 100000;
        speed = speed + koeff;
    }

   
}

