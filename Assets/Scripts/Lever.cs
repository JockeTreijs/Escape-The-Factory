﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public UnityEngine.Vector3 initialPosition = new UnityEngine.Vector3(7, 0, 3);
    public UnityEngine.Vector3 endPosition = new UnityEngine.Vector3(7, 3, 3);
    public float speed;
    public bool leverUsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && transform.position != endPosition && leverUsed == false)
            {
                StartCoroutine(OpenDoorRoutine());
                leverUsed = true;

            }
        }
    }

    IEnumerator OpenDoorRoutine()
    {
        while (door.transform.position != endPosition)
        {
            door.transform.position = UnityEngine.Vector3.MoveTowards(door.transform.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}