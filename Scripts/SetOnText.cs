using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetOnText : MonoBehaviour
{
   
   
    private playerController playerControllerScript;
    [SerializeField] Text text;
    public void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<playerController>();
       // text = GetComponent<Text>();
    }
    void Update()
    {
        text.enabled = false;
        if (playerControllerScript.isGameOver == true)
        {
            text.enabled = true;
        }
       
    }
}
