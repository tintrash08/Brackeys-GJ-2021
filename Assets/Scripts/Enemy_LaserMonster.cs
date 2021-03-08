using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_LaserMonster : MonoBehaviour {
    public NavMeshAgent agent;
    public GameObject player;

    public Animator animator;

    public AudioClip bigMonsterSFX;

    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
        agent = GetComponent<NavMeshAgent> ();
        
    }

    void Update () {
        animator.SetTrigger ("Run");
        agent.SetDestination (player.transform.position);
        AudioManager.instance.PlaySFX(bigMonsterSFX, 0.005f);
    }
}