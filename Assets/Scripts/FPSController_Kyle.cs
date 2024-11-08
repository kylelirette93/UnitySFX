using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller_Kyle : MonoBehaviour
{
    public float mouseSensitivity;
    public float movementSpeed;
    public Camera mainCamera;
    public Transform groundCheck;
    public LayerMask groundLayer;

    float gravity = 10f;
    float jumpHeight = 1f;
    float groundDistance = 0.4f;
    bool isGrounded;
    Vector3 lookAngle;
    CharacterController controller;
    Vector3 velocity;

    void Start()
    {
        if (!TryGetComponent<CharacterController>(out controller))
        {
            controller = gameObject.AddComponent<CharacterController>();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lookAngle.y = mainCamera.transform.rotation.eulerAngles.y;
        lookAngle.x = mainCamera.transform.rotation.eulerAngles.x;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float zInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        lookAngle.x -= mouseY;
        lookAngle.y += mouseX;

        // Rotate horizontally
        transform.rotation = Quaternion.Euler(0f, lookAngle.y, 0f);

        // Limits vertical camera rotation
        lookAngle.x = Mathf.Clamp(lookAngle.x, -90f, 90f);
        Quaternion mouseLook = Quaternion.Euler(lookAngle.x, lookAngle.y, 0);
        mainCamera.transform.rotation = mouseLook;

        // Move player based on input
        Vector3 movement = transform.right * xInput + transform.forward * zInput;
        controller.Move(movement * movementSpeed * Time.deltaTime);

        // Handle jumping if grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        // Apply gravity to movement velocity on the y axis
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}