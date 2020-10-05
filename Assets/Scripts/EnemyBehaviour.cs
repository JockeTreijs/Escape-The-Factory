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
    private BoxCollider visionCollider;
    private bool engagePlayer = false;
    private bool canAttack;
    private bool checkTarget = false;
    public void Start()
    {
        stunDuration = 3;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
        visionCollider = GetComponent<BoxCollider>();
        canAttack = true;
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
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            GoToNextPoint();
        }
        if (checkTarget)
        {// Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;
            //// This would cast rays only against colliders in layer 8.
            //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;
            RaycastHit hit;
            // Does the ray intersect any objects excluding the enemy layer
            if (Physics.Raycast(transform.position, target.position, out hit, 999f, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.DrawRay(transform.position, target.position * hit.distance, Color.yellow);
                    Debug.Log("Did Hit");
                    EngageTarget();
                }
            }
            else
            {
                Debug.DrawRay(transform.position, target.transform.position * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
    void FixedUpdate()
    {
        //if (checkTarget)
        //{// Bit shift the index of the layer (8) to get a bit mask
        //    int layerMask = 1 << 8;

        //    //// This would cast rays only against colliders in layer 8.
        //    //// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //    layerMask = ~layerMask;

        //    RaycastHit hit;
        //    // Does the ray intersect any objects excluding the player layer
        //    if (Physics.Raycast(transform.position, target.position, out hit, 99999999f, layermas))
        //    {
        //        if (hit.collider.gameObject.CompareTag("Player"))
        //        {
        //            Debug.DrawRay(transform.position, target.position * hit.distance, Color.yellow);
        //            Debug.Log("Did Hit");
        //            EngageTarget();
        //        }
        //    }
        //    else
        //    {
        //        Debug.DrawRay(transform.position, target.transform.position * 1000, Color.white);
        //        Debug.Log("Did not Hit");
        //    }
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            engagePlayer = true;
            target = other.transform;
            checkTarget = true;
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
        checkTarget = false;
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
