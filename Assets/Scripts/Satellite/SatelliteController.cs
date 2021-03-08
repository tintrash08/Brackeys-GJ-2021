using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    public Transform[] AlienDoodsPositions;
    public AudioClip SatelliteSFX;
    public AudioClip SatelliteSFX2;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("SATELLITE CONTACTED");
            AudioManager.instance.PlaySFX(SatelliteSFX);
            PlaceAlienDood();
        }
    }

    void PlaceAlienDood() {
        GameManager GM = GameManager.instance;
        if(GM.canPickMore()) {

            AudioManager.instance.PlaySFX(SatelliteSFX2);

            int currentDoods = GM.currentDoods;
            int doodIndex = currentDoods; --doodIndex;
            string doodName = "Alien_" + currentDoods;
            GameObject AlienDood = GM.AlienDoodHoldPosition.Find(doodName).gameObject;
            AlienDood.transform.position = AlienDoodsPositions[doodIndex].position;
            AlienDood.transform.parent = null;
            AlienDood.transform.parent = AlienDoodsPositions[doodIndex];
            GM.isPlayerCarryingDood = false;
            GM.updateSignalProgress(AlienDood.GetComponent<AlienDood>().powerValue);
            GM.isPlayerInMission = false;
        }
    }
    
    void Start() { }

    void Update() { }
}
