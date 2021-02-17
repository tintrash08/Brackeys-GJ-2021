using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] int waveIntervalCounter;
    [SerializeField] Text uiCounter;
    [SerializeField] List<WaveEnemyPool> _wavePools;

    internal bool isNewWave = true;

    void Start() 
    {
        uiCounter.enabled = false;
    }

    void Update()
    {
        if (isNewWave && _wavePools.Count > 0) StartCoroutine(SpawnNewWave());
        else if (_wavePools.Count <= 0) PlayerWon();
    }

    ///<summary>
    /// Coroutine to start the wave counter and enable the WaveEnemyPool after the timer
    ///</summary>
    IEnumerator SpawnNewWave()
    {
        isNewWave = false;
        uiCounter.enabled = true;   
        
        float timer = 0; 

        while (timer <= waveIntervalCounter) 
        {
            uiCounter.text = (timer).ToString("000") +  " s";
            timer += Time.deltaTime;
            yield return null;
        }

        uiCounter.text = "GET READY!!!!!";
        yield return new WaitForSeconds(5.0f);
        uiCounter.text = "GO!!";
        yield return new WaitForSeconds(0.5f);
        uiCounter.enabled = false;   

        _wavePools[0].ActivateEnemies();
        _wavePools.RemoveAt(0);

        //TODO remove this - used for debugging
        isNewWave = true;

        yield return null;
    }

    ///<summary>
    /// Set the state to Won if there is no more waves to spawn
    ///</summary>
    void PlayerWon()
    {
        isNewWave = false;
        uiCounter.enabled = true;
        uiCounter.text = "YOU WON!!!";
    }
}
