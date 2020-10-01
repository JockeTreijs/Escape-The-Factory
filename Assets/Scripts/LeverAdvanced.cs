using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAdvanced : MonoBehaviour
{
    public DoorAdvanced doorAdvanced;
    public bool leverUsed;

    // Start is called before the first frame update
    void Start()
    {
        doorAdvanced = GameObject.Find("DoorAdvanced").GetComponent<DoorAdvanced>();
        leverUsed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && leverUsed == false)
            {
                leverUsed = true;
                doorAdvanced.OpenDoor();
            }
        }
    }

    
}
