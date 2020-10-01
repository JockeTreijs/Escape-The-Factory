using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class OilCan : MonoBehaviour
{
    public Player player;
    public bool pickedUp;
    public GameObject oilCan;
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                oilCan.transform.parent = mainCamera.transform;
                pickedUp = true;
            }

            if (Input.GetKeyDown(KeyCode.F) && pickedUp == true)
            {
                player.AddHealth(1);
                Destroy(gameObject);
            }
        }
    }


}
