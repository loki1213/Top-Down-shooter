using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenager : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Score(int scoVal)
    {
        score += scoVal;
    }
}
