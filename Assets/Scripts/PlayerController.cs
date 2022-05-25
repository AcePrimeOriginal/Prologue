using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int walkingSpeed, runningSpeed;
    public int movementSpeed;
    public int moveAmount;
    public float turnSmoothTime;
    public float mouseSensitivity;
    public bool isSprinting;


    //Jump Stuff
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3;

    CharacterController charController;
    public Transform playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        Vector3 moveAmount = Vector3.zero;
        movementSpeed = isSprinting ? runningSpeed : walkingSpeed;
        Jumping(moveAmount);
        velocity.y += gravity * Time.deltaTime;
        moveAmount.y = velocity.y;
        moveAmount.z = Input.GetAxis("Vertical") * movementSpeed;
        moveAmount.x = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 direction = transform.TransformDirection(moveAmount);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
        charController.Move(direction * Time.deltaTime);
    }

    void Jumping(Vector3 moveDir)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && moveDir.magnitude <= 0.05f)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
    }
}
