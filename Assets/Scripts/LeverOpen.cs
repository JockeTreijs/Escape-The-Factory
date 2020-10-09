using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpen : MonoBehaviour
{
    private bool startRotate = false;
    public float rotateSpeed;
    public void RotateLever()
    {
        startRotate = true;
    }

    private void Update()
    {
        if (startRotate && transform.rotation.x >= -90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x - rotateSpeed + Time.deltaTime, transform.rotation.y, transform.rotation.z);
        }
    }
}
