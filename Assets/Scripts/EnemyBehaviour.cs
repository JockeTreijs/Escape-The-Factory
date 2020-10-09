using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private float maxHealth = 3; //enemy max health
    public float currentHealth; //enemy current health
    private float minHealth = 1; //the minimum health the enemy can haves
    private float stunDuration; //how long the enemy is stunned, 3 by default as noted in the start
    private float stunStart;
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
    private Rigidbody rb;
    public Light spotLight;
    private Color lightColorBase;
    public Color lightColorAngry;
    public Color lightColorStunned;

    public Light faceLight;
    public Light faceRoundLight;
    

    private bool coroutineActive = false;

    public AudioSource lockOn;
    public ParticleSystem leftZap;
    public ParticleSystem rightZap;

    public int minHeight = 0;

    public void Start()
    {
        zapSphere = GetComponent<SphereCollider>();
        visionCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        stunDuration = 3;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
        canAttack = false;
        lightColorBase = spotLight.color;
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
        else if (engagePlayer && coroutineActive == false)
        {
            EngageTarget();
        }
        if (canAttack && Time.time >= startTime + droneAtkCD)
        {
            leftZap.Play(true);
            rightZap.Play(true);
            target.GetComponent<Player>().RemoveHealth(enemyDamage);
            startTime = Time.time;
            canAttack = false;
            //INSERT ZAP ANIMATION HERE
        }
        transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && coroutineActive == false)
        {
            engagePlayer = true;
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && coroutineActive == false)
        {
            engagePlayer = false;
            target = null;
            spotLight.color = lightColorBase;
            faceLight.color = lightColorBase;
            faceRoundLight.color = lightColorBase;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canAttack = true;
            lockOn.Play(0);
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
        if (currentHealth == 2) //if the enemys health is down to 2 points after taking damage, it will be stunned and increase the NEXT stun by 2 seconds
        {
            StartCoroutine(Stunned(stunDuration));
            stunDuration = stunDuration + 2;
        }

        if (currentHealth == 1) //if the enemys health is down to 1 point after taking damage, it will be stunned for 5 seconds
        {
            StartCoroutine(Stunned(stunDuration));
        }

        if (currentHealth < minHealth)
        {
            Death();
        }

    }
    void EngageTarget()
    {
        agent.destination = target.position;
        spotLight.color = lightColorAngry;
        faceLight.color = lightColorAngry;
        faceRoundLight.color  = lightColorAngry;
    }
    void Death()
    {
        Destroy(gameObject); // death :(
    }
    IEnumerator Stunned(float stunDuration)
    {
        coroutineActive = true;
        canAttack = false;
        agent.isStopped = true;
        faceLight.color = lightColorStunned;
        faceRoundLight.color = lightColorStunned;
        spotLight.color = lightColorStunned;
        yield return new WaitForSeconds(stunDuration);
        coroutineActive = false;
        faceLight.color = lightColorBase;
        faceRoundLight.color = lightColorBase;
        spotLight.color = lightColorBase;
        agent.isStopped = false;
        //GoToNextPoint();
        yield return null;
    }
}
