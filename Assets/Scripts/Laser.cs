using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //public Transform startPoint;
    //public Transform endPoint;

    public GameObject player;
    public GameObject PewEnemy_GO;
    public LineRenderer lineRenderer;

    public float sightRadius = 15f;
    //public bool isPlayerInRadius=false;

    public float attackStrength = 0.2f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isPlayerInRadius = CheckIfPlayerInRadius();
        CheckIfPlayerInSight();
    }


    void LookAtPlayer(Vector3 targetDirection)
    {
        Quaternion neededRotation = Quaternion.LookRotation(targetDirection);
        PewEnemy_GO.transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * 50f);
    }
    /*bool CheckIfPlayerInRadius()
    {
        if (Vector3.Distance(transform.position,player.transform.position)<sightRadius)
        {
            return true;
        }
        return false;
    }*/

    void CheckIfPlayerInSight()
    {
        RaycastHit hit;
        Vector3 playerDirection = player.transform.position - transform.position;       //vector between player and laser starting pos
        Debug.DrawRay(transform.position, playerDirection, Color.red);

        LookAtPlayer(playerDirection);
        float angle = Vector3.Angle(playerDirection, transform.forward);

        //Debug.Log(angle);

        if (angle < 40f)
        {
            //PewEnemy_GO.transform.LookAt(player.transform);
            if (Physics.Raycast(transform.position, playerDirection, out hit, sightRadius))      //Check if raycast hit something
            {
                
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.transform.CompareTag("Player"))     //check if player is hit
                {
                    
                    Shoot();
                }
                else
                {
                    lineRenderer.enabled = false;
                }
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void Shoot()
    {
        animator.SetTrigger("Attack");
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
        //apply damage to player
        player.GetComponent<Health>().ChangeHealth(-attackStrength * Time.deltaTime);
    }
}
