using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] prefabs;
    private bool left;
    private float timeStamp;
    private GameObject[] smallSum;
    private GameObject[] bigSum;


    void Update()
    {
        //checking if there is more than 12 enemies
        smallSum = GameObject.FindGameObjectsWithTag("smallEnemy");
        bigSum = GameObject.FindGameObjectsWithTag("bigEnemy");

        if ((Time.time >= timeStamp) & (bigSum.Length + smallSum.Length < 12)) //czas się zgadza i jest mniej niż 13 potworków
        {
            left = true;
            //randomize if monster will spawn from left side or right
            if (Random.Range(0.0f, 1.0f) < 0.5f) 
            { 
                left = false; 
            }

            if (left == true)
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(0, 0, Random.Range(0, 13)), Quaternion.identity);
            }
            else
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(23, 0, Random.Range(0, 13)), Quaternion.identity);
            }

            //limiting spawning to five seconds
            timeStamp = Time.time + 5;
        }
    }
}
