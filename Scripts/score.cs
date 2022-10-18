using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float time_of_running = 0;
    [SerializeField] public Text scoreText;
    [SerializeField] public Transform player;
 //   private float koeff = 1;
  
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
            time_of_running = time_of_running + 1 * Time.deltaTime;
           // koeff = 1 + time_of_running / 100;
            scoreText.text = ((int)(time_of_running)).ToString();
        }
        
        
    }
    
}
