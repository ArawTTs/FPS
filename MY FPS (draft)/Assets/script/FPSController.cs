using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private CharacterController characterController;
    private Camera playerCamera;
   
    private float verticalRotation = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Player movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float strafeSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(strafeSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        characterController.SimpleMove(speed);

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}