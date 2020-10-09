using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] prefabs;
    public bool PowerUp = false;
    private GameObject pickups;

    void Update()
    {
        pickups = GameObject.FindWithTag("pickup");

        if ((UnityEngine.Random.Range(0, 2400) == 1) & (pickups == null))
        {
            if ((UnityEngine.Random.Range(0, 1) < 0.5) & (PowerUp == false))
            {
                Instantiate(prefabs[1], new Vector3(UnityEngine.Random.Range(2, 21), 0, UnityEngine.Random.Range(2, 11)), Quaternion.identity);
                PowerUp = true;
            }
            else
            {
                Instantiate(prefabs[0], new Vector3(UnityEngine.Random.Range(2, 21), 0, UnityEngine.Random.Range(2, 11)), Quaternion.identity);
            }
        }
    }
}
