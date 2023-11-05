using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Transform References")]
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform playerHead;
    [SerializeField] Transform playerCam;

    [Space(10)]

    [Header("Movement values")]
    [SerializeField] float playerSpeed;
    [SerializeField] float playerGravity;
    [SerializeField] float groundDistance;
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundMask;

    [Space(10)]

    [Header("Camera values")]
    [SerializeField] float mouseSensitivity;
    [SerializeField] float cameraBendingAmplitude;
    [SerializeField] float cameraBendingSpeed;

    [Space(10)]

    [Header("Player states")]
    [SerializeField] bool isGrounded;
    [SerializeField] bool isWalking;

    CharacterController characterController;
    HeadBobbing headBobbing;
    float xRotation = 0;
    [HideInInspector] public Vector3 moveDirection;
    Vector3 velocity, defaultHeadPos;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        defaultHeadPos = playerHead.transform.localPosition;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (GetComponent<HeadBobbing>())
            headBobbing = GetComponent<HeadBobbing>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isWalking = moveDirection.magnitude > 0;

        Move();

        Jump();

        Rotate();

        CameraBending();

        headBobbing?.EnableBobbing(moveDirection, playerHead, defaultHeadPos, isGrounded);

    }



    void Move()
    {
        moveDirection = gameObject.transform.forward * Input.GetAxisRaw("Vertical") + gameObject.transform.right * Input.GetAxisRaw("Horizontal");
        characterController.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * playerGravity);

        velocity.y -= playerGravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        gameObject.transform.Rotate(Vector3.up * mouseX);
    }

    void CameraBending()
    {
        float cameraBending = -Input.GetAxisRaw("Horizontal") * cameraBendingAmplitude;
        playerCam.transform.localRotation = Quaternion.RotateTowards(playerCam.transform.localRotation, Quaternion.Euler(0, 0, cameraBending), cameraBendingSpeed * 0.1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundDistance);
    }
}
