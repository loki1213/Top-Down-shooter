using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MonsterBigBehaviour : MonoBehaviour
{
    private GameObject player;
    private GameObject scoreMenager;
    private ScoreMenager scoreMenagerScript;
    public int hp = 10;
    public float speed = 5;
    private ParticleSystem meat;
    private Animator anim;
    private BoxCollider collider;
    public float rotationSpeed = 1.0f;
    public int scoreValue = 20;
    private AudioSource damage;
    
    


    public void Start()
    {
        player = GameObject.Find("Player");
        meat = GetComponentInChildren(typeof(ParticleSystem)) as ParticleSystem;
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        scoreMenager = GameObject.Find("ScoreMenager");
        scoreMenagerScript = scoreMenager.GetComponent<ScoreMenager>();
        damage = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (hp > 0)
        {
            MonsterAI();
        }     
    }

    IEnumerator Damage(int damVal)
    {
        hp -= damVal;
        meat.Play();

        if (hp < 1)
        {
            scoreMenagerScript.score += scoreValue;
            anim.Play("Dead");
            Destroy(collider);
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }

    public void MonsterAI()
    {
        //making monster rotating towards the player
        Vector3 targetDirection = player.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        //making monster walking towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage", 2);
            StartCoroutine(Damage(10));
            damage.Play();
        }
    }
}
