using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    private Text text;
    private GameObject scoreMenager;
    private ScoreMenager scoreMenagerScript;


    void Start()
    {
        text = GetComponent<Text>();
        scoreMenager = GameObject.Find("ScoreMenager");
        scoreMenagerScript = scoreMenager.GetComponent<ScoreMenager>();
    }


    void Update()
    {
        text.text = "Game is over. You have scored " + scoreMenagerScript.score + " points. Press enter to play again or escape to exit";

        if (Input.GetAxis("Submit") == 1)
        {
            scoreMenagerScript.score = 0;
            SceneManager.LoadScene("Play");
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
