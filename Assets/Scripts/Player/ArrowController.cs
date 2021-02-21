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
            // if(!GM.isPlayerCarryingDood || GM.isPlayerInMission) {
            //     int doodIndex = GM.currentDoods; --doodIndex;
            //     
            // } else {
            //     transform.LookAt(satellitePosition);
            // }

            int doodIndex = GM.currentDoods;
            // if(GM.currentDoods == 0) doodIndex = 0; else --doodIndex;
            Debug.Log("CURRENT DOODS " + GM.currentDoods);
            Debug.Log("DOOD INDEX " + doodIndex);
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
