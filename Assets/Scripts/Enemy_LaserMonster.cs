using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_LaserMonster : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("Run");
        agent.SetDestination(player.transform.position);
    }
}
