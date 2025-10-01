using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 12.0f;
    public float sprintSpeed = 16f;
    public float staminaPerRun = 0.1f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded = false;
    public static bool isInDialogue = false;
    public static bool canMove = true;

    private CharacterController controller;
    private bool setTrigger = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            float s = speed;
            
            setTrigger = setTrigger || Input.GetKeyDown(KeyCode.LeftShift);
            if(Input.GetKeyUp(KeyCode.LeftShift)) setTrigger = false;
            if(setTrigger && Player.realStamina > 0)
            {
                s = sprintSpeed;
                FindFirstObjectByType<Player>().ReduceStamina(staminaPerRun * Time.deltaTime);
            }
            else
            {
                setTrigger = false;
            }
            Vector3 move = transform.forward * z + transform.right * x;

            controller.Move(move * s * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
