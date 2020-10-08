using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    public Camera cam;
    public AudioSource walkingSound;
    public AudioClip walkingClip;
    private bool walking = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        InvokeRepeating("PlaySound", 0.5f, 0.75f);
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((cam.transform.right * horizontal + cam.transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
    void PlaySound()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            walkingSound.PlayOneShot(walkingClip);
        }
    }
}
