using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    public Transform[] AlienDoodsPositions;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("SATELLITE CONTACTED");
            PlaceAlienDood();
        }
    }

    void PlaceAlienDood() {
        if(GameManager.instance.canPickMore()) {
            int currentDoods = GameManager.instance.currentDoods;
            int doodIndex = currentDoods; --doodIndex;
            string doodName = "Alien_" + currentDoods;
            transform.position = GameManager.instance.AlienDoodHoldPosition.position;
            GameObject AlienDood = GameManager.instance.AlienDoodHoldPosition.Find(doodName).gameObject;
            AlienDood.transform.position = AlienDoodsPositions[doodIndex].position;
            AlienDood.transform.parent = null;
            AlienDood.transform.parent = AlienDoodsPositions[doodIndex];
            GameManager.instance.isPlayerCarryingDood = false;
        }
    }
    
    void Start() { }

    void Update() { }
}
