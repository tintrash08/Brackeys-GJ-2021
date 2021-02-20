using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public const float MAX_POWER_NEEDED = 100f;
    public const float MAX_DOODS_NEEDED = 3f;
    public int currentDoods = 0;
    public float satelliteSignalProgress = 0;
    public bool isPlayerCarryingDood = false;
    public Transform AlienDoodHoldPosition;

    public void updateDoodsCounter() {
        if(!canPickMore()) {
            currentDoods++;
            Debug.Log("GOT ONE!!");
            Debug.Log("YOU HAVE " + currentDoods + " DOODS NOW!!");
        }
    }

    public bool canPickMore() {
        return !isPlayerCarryingDood && currentDoods < MAX_DOODS_NEEDED ? false : true;
    }

    void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);
        }
    }

    void Start () { }
    void Update () { }
}
