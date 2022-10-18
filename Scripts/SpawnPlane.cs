using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{

    public GameObject obstaclePlane;

    private float tmin = 15f;
    private float tmax = 25f;

    private float startDelay;
    private float repeatRate = 2;

    private Vector3 spawnPosPlane;
    private playerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        startDelay = Random.Range(tmin, tmax);
        randomPosition();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePlane, spawnPosPlane, obstaclePlane.transform.rotation);
        }
    }
    void randomPosition()
    {
        float randomY = Random.Range(5.8f, 8);
        spawnPosPlane = new Vector3(70, randomY, 4.2f);
    }
}
