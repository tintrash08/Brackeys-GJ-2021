using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDood : MonoBehaviour {

    public Vector3 lookAtMeDood = new Vector3(0f, 145f, 0f);
    public int powerValue = 0;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PickUpAlienDood();
        }
    }

    void PickUpAlienDood() {
        GameManager GM = GameManager.instance;
        if(!GM.canPickMore()) {
            GM.updateDoodsCounter();
            GM.isPlayerCarryingDood = true;
            transform.position = GM.AlienDoodHoldPosition.position;
            transform.eulerAngles = lookAtMeDood;
            transform.parent = null;
            transform.parent = GM.AlienDoodHoldPosition;
        }
    }

    void Start() { }

    void Update() { }
}
