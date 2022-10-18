using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetOffText : MonoBehaviour
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
        if (playerControllerScript.isGameOver == true)
        {
            text.enabled = false;
        }

    }
}
