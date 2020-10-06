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
    public float distance;
    public float throwSpeed;
    public GameObject throwableOilcan;

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
                oilCan.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
                pickedUp = true;
            }

            if (Input.GetKeyDown(KeyCode.F) && pickedUp == true && player.health <=2)
            {
                player.AddHealth(1);
                Destroy(gameObject);
            }

            if (Input.GetMouseButtonDown(1) && pickedUp == true)
            {
                ThrowOilcan();
                Destroy(gameObject);
            }
        }
    }
    public void ThrowOilcan()
    {
            UnityEngine.Vector3 spawnPoint = transform.position + (transform.rotation * new UnityEngine.Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z));
            GameObject fire = Instantiate(throwableOilcan, spawnPoint, UnityEngine.Quaternion.identity);
            fire.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * throwSpeed);
    }
}
