using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
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
        text.text = "Score: " + scoreMenagerScript.score;
    }
}
