using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDoubleOpen : MonoBehaviour
{
    public GameObject doorOne;
    public int openDoorNumber;
    private UnityEngine.Vector3 initialPosition = new UnityEngine.Vector3(25, 0, 15);
    private UnityEngine.Vector3 endPosition = new UnityEngine.Vector3(25, 0.5f, 15);
    private UnityEngine.Vector3 initialPosition1 = new UnityEngine.Vector3(25, 0.5f, 15);
    private UnityEngine.Vector3 endPosition1 = new UnityEngine.Vector3(25, 3, 15);
    public bool openDoor = false;

    public AudioClip airLock;
    public AudioSource audioSource;
    //public float doorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        endPosition = new Vector3(doorOne.transform.position.x, doorOne.transform.position.y + 1.5f, doorOne.transform.position.z);
        endPosition1 = new Vector3(doorOne.transform.position.x, doorOne.transform.position.y + 1.5f, doorOne.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != endPosition || transform.position != endPosition1)
        {
            if (openDoorNumber == 1)
            {
                doorOne.transform.position = UnityEngine.Vector3.MoveTowards(doorOne.transform.position, endPosition, 1f * Time.deltaTime);
            }
            if (openDoorNumber == 2)
            {
                doorOne.transform.position = UnityEngine.Vector3.MoveTowards(doorOne.transform.position, endPosition1, 1f * Time.deltaTime);
            }
        }
    }

    public void OpenDoor()
    {

        Debug.Log("Do I open??!!!!");
        openDoorNumber++;
        //StartCoroutine(OpenDoorRoutine());
    }
    public void PlaySound()
    {
        audioSource.Play(0);
    }
}
