using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //public Transform startPoint;
    //public Transform endPoint;

    public GameObject player;
    public LineRenderer lineRenderer;

    public float sightRadius = 15f;
    public bool isPlayerInSight=false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, player.transform.position);

        isPlayerInSight = CheckIfPlayerInSight();
    }

    bool CheckIfPlayerInSight()
    {
        if (Vector3.Distance(transform.position,player.transform.position)<sightRadius)
        {
            return true;
        }
        return false;
    }
}
