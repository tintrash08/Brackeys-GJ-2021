using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {
    Vector3 hitTarget;
    public float shotSpeed;
    void Start() { }

    void Update() {
        float step = shotSpeed * Time.deltaTime;
        if (hitTarget != null) {
            if (transform.position == hitTarget) {
                // Add hit effect || explosion || knokback
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, hitTarget, step);
        }
    }

    public void setTarget(Vector3 target) {
        hitTarget = target;
    }
}
