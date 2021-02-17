using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveHandler : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            gameObject.SetActive(false);
            Dead();
        }
    }

    #region Delegate to Create the OnDestroy Event

    internal delegate void EnemyDie(GameObject t);
    internal event EnemyDie OnEnemyDestroy;

    internal void Dead() => OnEnemyDestroy(this.gameObject);

    #endregion
}
