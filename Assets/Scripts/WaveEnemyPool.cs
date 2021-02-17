using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyPool : MonoBehaviour
{
    //TODO Change the list of GO to be a list of Enemies Script
    [SerializeField] List<GameObject> enemyPool;
    WaveSystem parentSystem;


    void Start()
    {
        parentSystem = GetComponentInParent<WaveSystem>();
        foreach(GameObject go in enemyPool)
        {
            go.SetActive(false);
        }
    }

    void Update() 
    {
        if (parentSystem) Debug.Log("Parent located");
        //TODO check for childrens (enemies) if there is not change Parent state
    }

    ///<summary>
    /// Method to enable all the enemies in the pool
    ///</summary>
    internal void ActivateEnemies()
    {
        foreach(GameObject go in enemyPool)
        {
            go.SetActive(true);
        }
    }
}
