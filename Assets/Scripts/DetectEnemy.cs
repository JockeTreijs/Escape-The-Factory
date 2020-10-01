using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public GameObject player; //this is our player
    public BoxCollider EnemyCol; // this is a trigger and it checks whatever is infront of the player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            player.GetComponent<WrenchBehaviour>().CanHit = true; //this tells the player that they can attack
            player.GetComponent<WrenchBehaviour>().target = other.gameObject; //this sets the players target to enemy
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            player.GetComponent<WrenchBehaviour>().CanHit = false;
            player.GetComponent<WrenchBehaviour>().target = null;
        }
    }
}
