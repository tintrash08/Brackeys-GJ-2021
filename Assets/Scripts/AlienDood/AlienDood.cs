using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDood : MonoBehaviour {

    public Vector3 lookAtMeDood = new Vector3(0f, 145f, 0f);
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PickUpAlienDood();
        }
    }

    void PickUpAlienDood() {
        if(!GameManager.instance.canPickMore()) {
            GameManager.instance.updateDoodsCounter();
            GameManager.instance.isPlayerCarryingDood = true;
            transform.position = GameManager.instance.AlienDoodHoldPosition.position;
            transform.eulerAngles = lookAtMeDood;
            transform.parent = null;
            transform.parent = GameManager.instance.AlienDoodHoldPosition;
        }
    }

    void Start() { }

    void Update() { }
}
