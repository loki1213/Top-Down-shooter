using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    private Text text;
    public GameObject player;
    private Shooting shooting;

    void Start()
    {
        text = GetComponent<Text>();
        shooting = player.GetComponent<Shooting>();
    }


    void Update()
    {
        text.text = "" + shooting.ammo;
    }
}

