using System.Collections;
using System.Collections.Generic;
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
    public GameObject target;
    public NavMeshAgent agent;
    public void Start()
    {
        stunDuration = 3;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
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
    void Death()
    {
        Destroy(gameObject); // death :(
    }
    void Stun()
    {
        //make the drone be stunned here
    }



}
