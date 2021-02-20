using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{
    internal void Dead() {
        WaveEnemyPool wavePool = GetComponentInParent<WaveEnemyPool>(); 
        if (wavePool) wavePool.OnEnemyDestroyEvent(this.gameObject);
    } 
}
