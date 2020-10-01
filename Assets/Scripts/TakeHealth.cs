using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.RemoveHealth(1);
            Destroy(gameObject);
        }
    }
}
