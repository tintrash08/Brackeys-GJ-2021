using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyPool : MonoBehaviour
{
    [SerializeField] List<Transform> enemyPool = new List<Transform>();
    WaveSystem parentSystem;

    void Start()
    {
        //Reference to parent - Wave Enemy System
        parentSystem = GetComponentInParent<WaveSystem>();

        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t != this.transform)
            {
                enemyPool.Add(t);
                this.gameObject.SetActive(false);
                t.gameObject.GetComponent<EnemyWaveHandler>().OnEnemyDestroy += OnEnemyDestroyEvent;
            }
        }
    }

    ///<summary>
    /// Method to enable all the enemies in the pool
    ///</summary>
    internal void ActivateEnemies()
    {
        this.gameObject.SetActive(true);
    }


    ///<summary>
    /// To be called in the enemy script so the pool can remove it from the list
    ///</summary>
    internal void OnEnemyDestroyEvent(GameObject t)
    {
        enemyPool.Remove(t.transform);
        parentSystem.isNewWave = true;
        //Check for childrens (enemies) if there is not change Parent state
        // if (GetComponentsInChildren<Transform>().Length <= 0) 
    }
}
