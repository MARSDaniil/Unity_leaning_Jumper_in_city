using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
   
    public GameObject[] obstaclePrefabs;
    
    private Vector3 spawnPosObstacle = new Vector3(25, 0, 0);
    private float startDelay = 3;
    private float repeatRate = 2;
    private playerController playerControllerScript; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefabs[index], spawnPosObstacle, obstaclePrefabs[index].transform.rotation);
        }
    }
}
