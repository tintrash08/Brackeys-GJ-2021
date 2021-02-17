using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
