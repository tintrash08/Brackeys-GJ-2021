using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone : MonoBehaviour {
    public GameObject player;
    public float speed = 1.25f;

    public AudioClip FlyingMonsterSFX;
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update () {
        transform.LookAt (player.transform);
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
        AudioManager.instance.PlaySFX(FlyingMonsterSFX, 0.1f);
    }
}