using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] int waveIntervalCounter;
    [SerializeField] Text uiCounter;
    
    [SerializeField] List<WaveEnemyPool> _wavePools = new List<WaveEnemyPool>();
    int currentWave = 0;
    internal bool isNewWave = true;

    public GameObject[] AlienDoods;

    void Start() {
        uiCounter.enabled = false;
        if(currentWave == 0) {
            StartCoroutine(SpawnNewWave());
        }
    }

    void Update() {
        if(isNewWave) {
            int wave = currentWave;
            AlienDoods[--wave].SetActive(true);
        }

        if (isNewWave && _wavePools.Count > 0) {
            if(!GameManager.instance.isPlayerInMission) {
                StartCoroutine(SpawnNewWave());
            }
        } else if (currentWave > _wavePools.Count) PlayerWon();

        GameManager.instance.currentWave = currentWave;
    }

    ///<summary>
    /// Coroutine to start the wave counter and enable the WaveEnemyPool after the timer
    ///</summary>
    IEnumerator SpawnNewWave() {

        isNewWave = false;
        uiCounter.enabled = true;   
        
        float timer = 0; 

        while (timer <= waveIntervalCounter) {
            uiCounter.text = (timer).ToString("000") +  " s";
            timer += Time.deltaTime;
            yield return null;
        }

        uiCounter.text = "GET READY!!!!!";
        yield return new WaitForSeconds(2.0f);
        uiCounter.text = $"WAVE {currentWave + 1}!!!!!";
        yield return new WaitForSeconds(1.0f);
        uiCounter.text = "GO!!";
        yield return new WaitForSeconds(1.0f);
        uiCounter.enabled = false;   

        _wavePools[currentWave++].ActivateEnemies();
    }

    ///<summary>
    /// Set the state to Won if there is no more waves to spawn
    ///</summary>
    void PlayerWon() {
        isNewWave = false;
        uiCounter.enabled = true;
        uiCounter.text = "YOU WON!!!";
    }
}
