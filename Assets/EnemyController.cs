using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform patrolPoints_Parent;
    public Transform[] patrolPoints;
    int totalPatrolPoints;

    public bool isPatrolling = false;
    public bool isChasingPlayer = false;

    NavMeshAgent agent;
    public Vector3 nextPatrolPoint;

    public GameObject player;
    public float sightRadius = 15f;

    // Start is called before the first frame update
    void Start()
    {
        totalPatrolPoints = patrolPoints_Parent.childCount;
        SetupPatrolPoints();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void SetupPatrolPoints()
    {
        patrolPoints = new Transform[totalPatrolPoints];
        for (int i = 0; i < totalPatrolPoints; i++)
        {
            patrolPoints[i] = patrolPoints_Parent.GetChild(i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckPlayerPosition();
        Patrol();

    }


    void Patrol()
    {
        if (!isPatrolling & !isChasingPlayer)
        {
            AssignPatrolPoint();
        }
        agent.SetDestination(nextPatrolPoint);
        CheckIfReachedDestination();
    }
    void AssignPatrolPoint()
    {
        nextPatrolPoint = patrolPoints[Random.Range(0, totalPatrolPoints)].position;
        isPatrolling = true;
    }
    void CheckIfReachedDestination()
    {
        if (Vector3.Distance(transform.position, nextPatrolPoint) < 1f)
        {
            isPatrolling = false;
        }
    }
    void CheckPlayerPosition()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < sightRadius)
        {
            
            isChasingPlayer = true;
            nextPatrolPoint = player.transform.position;
        }
        else
        {
            isChasingPlayer=false;
        }
    }
}
