using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothCamera : MonoBehaviour
{
    public float mouseSensetivity = 1000f;
    public Transform playerBody;
    float xRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}