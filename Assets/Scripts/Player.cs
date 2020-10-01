using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveHealth (int playerHealth)
    {
        health -= playerHealth;
        gameManager.UpdateHealth(health);

    }

    public void AddHealth(int playerHealth)
    {
        health += playerHealth;
        gameManager.UpdateHealth(health);

    }
}
