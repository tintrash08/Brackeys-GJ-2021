using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {
    RaycastHit hitTarget;
    public float shotSpeed;
    void Start() { }

    void Update() {
        float step = shotSpeed * Time.deltaTime;
        if (hitTarget.point != null) {
            if (transform.position == hitTarget.point) {
                // Add hit effect || explosion || knokback
                if (hitTarget.transform) {
                    if (hitTarget.transform.CompareTag("Enemy")) {
                        hitTarget.transform.gameObject.GetComponent<Health>().ChangeHealth(-2);
                    }
                }
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, hitTarget.point, step);
        }
    }

    public void setTarget(RaycastHit target) {
        hitTarget = target;
    }
}
