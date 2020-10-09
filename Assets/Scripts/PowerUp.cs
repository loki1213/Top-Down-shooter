using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
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
            collision.gameObject.SendMessage("PowerUp");
            Destroy(gameObject);
        }
    }
}
