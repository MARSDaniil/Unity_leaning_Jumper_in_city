using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{ 
    
    // Start is called before the first frame update
    public Text scorePlayer;
    public Text scoreHight;
    private int scoreCounter;
    public float time_of_running = 0;
    private int hightScoreCounter;
    public static ScoreController instance;
    // private score scoreScript;
    private playerController playerControllerScript;
    private void Awake()
    {
        instance = this;
        if(PlayerPrefs.HasKey("SaveScore"))
        {
            hightScoreCounter = PlayerPrefs.GetInt("SaveScore");
        }
        
    }
    void Start()
    {
        // scoreScript = GameObject.Find("player").GetComponent<score>();
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
        scorePlayer.text = "Score: " + scoreCounter;
        scoreHight.text = "Highscore: " + hightScoreCounter;
        
    }
    public void AddScore()
    {
        if (playerControllerScript.isGameOver == false)
        {
            time_of_running = time_of_running + 1 * Time.deltaTime;
        }
        scoreCounter = (int)time_of_running;
        HightScore();
    }
    public void HightScore()
    {
        if(time_of_running > hightScoreCounter)
        {
            hightScoreCounter = (int)time_of_running;
            PlayerPrefs.SetInt("SaveScore", hightScoreCounter);
        }

    }
    public void ResetScore()
    {
        scoreCounter = 0;
    }
}
