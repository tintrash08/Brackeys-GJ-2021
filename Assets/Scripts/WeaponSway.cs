using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

    private Vector3 initialPosition;
    public float smoothSwayValue;
    public float lerpSmoothSwayValue;
    void Start() {
        initialPosition = transform.localPosition;
    }

    void Update() {
        float mouseX = -Input.GetAxis("Mouse X") * smoothSwayValue;
        float mouseY = -Input.GetAxis("Mouse Y") * smoothSwayValue;

        // mouseX = Mathf.Clamp(mouseX, -0.8f, 0.8f);
        // mouseY = Mathf.Clamp(mouseY, -0.8f, 0.8f);

        Vector3 swayPosition = new Vector3(mouseX, mouseY, 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, swayPosition + initialPosition, Time.deltaTime * lerpSmoothSwayValue);
    }
}
