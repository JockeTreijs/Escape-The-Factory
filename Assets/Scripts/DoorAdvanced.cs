using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAdvanced : MonoBehaviour
{
    public GameObject doorOne;
    public GameObject doorTwo;
    public GameObject doorThree;
    public int openDoorNumber;
    private UnityEngine.Vector3 initialPosition = new UnityEngine.Vector3(16, 0, 15);
    private UnityEngine.Vector3 endPosition = new UnityEngine.Vector3(16, 3, 15);
    private UnityEngine.Vector3 initialPosition1 = new UnityEngine.Vector3(18, 0, 15);
    private UnityEngine.Vector3 endPosition1 = new UnityEngine.Vector3(18, 3, 15);
    private UnityEngine.Vector3 initialPosition2 = new UnityEngine.Vector3(20, 0, 15);
    private UnityEngine.Vector3 endPosition2 = new UnityEngine.Vector3(20, 3, 15);
    public bool openDoor = false;
    //public float doorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        endPosition = new Vector3(doorOne.transform.position.x, doorOne.transform.position.y + 3, doorOne.transform.position.z);
        endPosition1 = new Vector3(doorTwo.transform.position.x, doorTwo.transform.position.y + 3, doorTwo.transform.position.z);
        endPosition2 = new Vector3(doorThree.transform.position.x, doorThree.transform.position.y + 3, doorThree.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != endPosition || transform.position != endPosition1 || transform.position != endPosition2)
        {
            if (openDoorNumber == 1)
            {
                doorOne.transform.position = UnityEngine.Vector3.MoveTowards(doorOne.transform.position, endPosition, 1f * Time.deltaTime);
            }
            if (openDoorNumber == 2)
            {
                doorTwo.transform.position = UnityEngine.Vector3.MoveTowards(doorTwo.transform.position, endPosition1, 1f * Time.deltaTime);
            }
            if (openDoorNumber == 3)
            {
                doorThree.transform.position = UnityEngine.Vector3.MoveTowards(doorThree.transform.position, endPosition2, 1f * Time.deltaTime);
            }
        }
    }

    public void OpenDoor()
    {
        openDoorNumber++;
        //StartCoroutine(OpenDoorRoutine());
    }

    //IEnumerator OpenDoorRoutine()
    //{
    //    //while (transform.position != endPosition || transform.position != endPosition1 || transform.position != endPosition2)
    //    //{
    //    //    if (openDoorNumber == 1)
    //    //    {
    //    //        doorOne.transform.position = UnityEngine.Vector3.MoveTowards(doorOne.transform.position, endPosition, 1f * Time.deltaTime);
    //    //    }
    //    //    if (openDoorNumber == 2)
    //    //    {
    //    //        doorTwo.transform.position = UnityEngine.Vector3.MoveTowards(doorTwo.transform.position, endPosition1, 1f * Time.deltaTime);
    //    //    }
    //    //    if (openDoorNumber == 3)
    //    //    {
    //    //        doorThree.transform.position = UnityEngine.Vector3.MoveTowards(doorThree.transform.position, endPosition2, 1f * Time.deltaTime);
    //    //    }
    //    //    yield return null;
    //    //}
    //}
}
