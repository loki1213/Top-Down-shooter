using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Shooting : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;
    public float weaponRange = 1000;
    public CharacterMovement chamov;
    public Vector3 direction;
    public float weaponRateOfFire;
    public float timeStamp;
    private AudioSource shotSound;
    //private ParticleSystem shootEffect;
    public int ammo = 60;
    private bool powerUp = false;


    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        //shootEffect = GetComponentInChildren(typeof(ParticleSystem)) as ParticleSystem;
    }

    void Update()
    {
        direction = GetComponent<CharacterMovement>().lookPos - transform.position;
    }

    void FixedUpdate()
    {
        if ((Input.GetMouseButton(0)) & (ammo > 0))
        {
            //Let's limit weapon's rate of fire
            if (Time.time > timeStamp)
            {
                timeStamp = Time.time + weaponRateOfFire;

                //Particle effect and  noise when shooting.
                //shootEffect.Play();

                shotSound.Play();

                //checking if we hit an enemy
                if (Physics.Raycast(transform.position, direction, out hit, weaponRange)) 
                {
                    if (hit.collider.tag == "bigEnemy")
                    {
                        hit.collider.SendMessage("Damage", 1);
                    }
                    else if (hit.collider.tag == "smallEnemy")
                    {
                        if (powerUp == true)
                        {
                            hit.collider.SendMessage("Damage", 2);
                        }
                        else
                        {
                            hit.collider.SendMessage("Damage", 1);
                        }
                    }

                }

                ammo -= 1;
            }
        }

    }

    void AmmoResupply(int resupply)
    {
        ammo += resupply;
    }

    void PowerUp()
    {
        powerUp = true;
    }
}
