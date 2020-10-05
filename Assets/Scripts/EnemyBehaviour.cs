using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private float maxHealth = 3; //enemy max health
    private float currentHealth; //enemy current health
    private float minHealth = 1; //the minimum health the enemy can haves
    private float stunDuration; //how long the enemy is stunned, 3 by default as noted in the start
    public Transform[] points;
    private int destPoint;
    public Transform target;
    public NavMeshAgent agent;
    public int currentPoint;
    public int enemyDamage = 1;
    private BoxCollider visionCollider;
    private bool engagePlayer = false;
    private bool canAttack;
    private bool checkTarget = false;
    private SphereCollider zapSphere;
    public float startTime = 0;
    public float droneAtkCD = 2;
    public void Start()
    {
        zapSphere = GetComponent<SphereCollider>();
        visionCollider = GetComponent<BoxCollider>();
        stunDuration = 3;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
        canAttack = false;
    }
    void GoToNextPoint()
    {
        if (engagePlayer == false)
        {
            if (points.Length == 0)
                return;
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
            currentPoint = destPoint;
        }
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 1f && engagePlayer == false)
        {
            GoToNextPoint();
        }
        else if (engagePlayer)
        {
            EngageTarget();
        }
        if (canAttack && Time.time >= startTime + droneAtkCD)
        {
            target.GetComponent<Player>().RemoveHealth(enemyDamage);
            startTime = Time.time;
            //INSERT ZAP ANIMATION HERE
        }
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            engagePlayer = true;
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            engagePlayer = false;
            target = null;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canAttack = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth < minHealth)
        {
            Death();
        }
        if (currentHealth == 2) //if the enemys health is down to 2 points after taking damage, it will be stunned and increase the NEXT stun by 2 seconds
        {
            Stun();
            stunDuration = stunDuration + 2;
        }
        else if (currentHealth == 1) //if the enemys health is down to 1 point after taking damage, it will be stunned for 5 seconds
        {
            Stun();
        }
    }
    void EngageTarget()
    {
        agent.destination = target.position;
    }
    void Death()
    {
        Destroy(gameObject); // death :(
    }
    void Stun()
    {
        //make the drone be stunned here
        //canAttack = false;
    }
}
