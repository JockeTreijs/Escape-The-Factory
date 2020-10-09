using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoubleOpen : MonoBehaviour
{
    public DoorDoubleOpen doorDoubleOpen;
    public bool leverUsed;
    public GameObject leverMod;
    // Start is called before the first frame update
    void Start()
    {
        doorDoubleOpen = GameObject.Find("DoorDoubleOpen").GetComponent<DoorDoubleOpen>();
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
                leverMod.GetComponent<LeverOpen>().RotateLever();
                leverUsed = true;
                doorDoubleOpen.OpenDoor();
            }
        }
    }


}
