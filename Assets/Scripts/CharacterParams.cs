using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterParams : MonoBehaviour
{
    public int player_HP = 10;
    public int score = 0;
    [SerializeField]
    private AudioSource damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Damage(int damVal)
    {
        player_HP -= damVal;

        if (player_HP < 1)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
