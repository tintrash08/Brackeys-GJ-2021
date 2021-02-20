using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public const int MAX_POWER_NEEDED = 100;
    public const int MAX_DOODS_NEEDED = 3;
    public int currentDoods = 0;
    public int satelliteSignalProgress = 0;
    public bool isPlayerCarryingDood = false;
    public Transform AlienDoodHoldPosition;

    public Text alienDoodsCounterText;
    public Text satelliteSignalProgressText;

    public void updateDoodsCounter() {
        if(!canPickMore()) {
            currentDoods++;
            Debug.Log("GOT ONE!!");
            Debug.Log("YOU HAVE " + currentDoods + " DOODS NOW!!");
        }
    }

    public void updateSignalProgress(int amount) {
        if(satelliteSignalProgress <= MAX_POWER_NEEDED) {
            satelliteSignalProgress += amount;
            Debug.Log("SIGNAL IS AT " + satelliteSignalProgress + "%");
        }
    }

    public bool canPickMore() {
        return !isPlayerCarryingDood && currentDoods < MAX_DOODS_NEEDED ? false : true;
    }

    Color getColor() {
        switch(satelliteSignalProgress) {
            case 30:
            return Color.red;
            break;
            case 70:
            return Color.yellow;
            break;
            case 100:
            return Color.green;
            break;
            default:
            return Color.red;
            break;
        }
    }

    void updateUI() {
        alienDoodsCounterText.text = "You found " + currentDoods.ToString() + " Alien Doods";
        satelliteSignalProgressText.text = "Signal is at " + satelliteSignalProgress.ToString() + "%";
        satelliteSignalProgressText.color = getColor();
    }

    void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);
        }
    }

    void Start () { }
    void Update () {
        updateUI();
    }
}
