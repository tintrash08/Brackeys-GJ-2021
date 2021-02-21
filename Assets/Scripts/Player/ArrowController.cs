using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

    public Transform[] AlienDoods;
    public Transform[] WavesPosition;
    public Transform satellitePosition;
    GameManager GM;
    void Start() {
        GM = GameManager.instance;
    }

    void Update() {
        if(GM.currentWave > 0) {
            int doodIndex = GM.currentDoods;
            int waveIndex = GM.currentWave; --waveIndex;
            if(GM.isPlayerCarryingDood) {
                transform.LookAt(satellitePosition);
            } else if(GM.isPlayerInMission) {
                transform.LookAt(AlienDoods[doodIndex]);
            } else {
                transform.LookAt(WavesPosition[waveIndex]);
            }
        }
    }
}
