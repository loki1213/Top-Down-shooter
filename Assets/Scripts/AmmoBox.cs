using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private BoxCollider collider;


    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("AmmoResupply", 60);
            Destroy(gameObject);
        }
    }
}
