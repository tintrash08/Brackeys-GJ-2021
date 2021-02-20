using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float mouseSensitivity = 200f;
    public Transform playerModel;
    public Transform playerWeapon;
    float xRotation = 0f;
    float mouseX;
    float mouseY;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        MouseInput();
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerModel.Rotate(Vector3.up * mouseX);
    }

    private void MouseInput() {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
