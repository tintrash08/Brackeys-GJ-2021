using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Camera FPSCamera;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 100f;
    public float destroyDuration = 4f;
    public float distance = 300f;
    public ParticleSystem muzzleEffect = null;
    public ParticleSystem hitEffect = null;
    public GameObject laserBeam;
    public float fireRate = 5f;
    public float fireDelay = 0f;

    void Start() { }

    void Update() {

        if (Input.GetMouseButton(0) && Time.time >= fireDelay) {
            fireDelay = Time.time + 1f/fireRate;
            ShootLaser();
        }

        // if (Input.GetMouseButton(0)) {
        //     Shoot1(); // basic bullet projectiles
        // }

        // if (Input.GetMouseButton(1)) {
        //     Shoot2(); // With raycasting (needs muzzle and hit effects)
        // }
    }

    private void ShootLaser() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, distance)) {
            GameObject lgo = GameObject.Instantiate(laserBeam, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            lgo.GetComponent<LaserBehavior>().setTarget(hit.point);
            GameObject.Destroy(lgo, 2f);
            Debug.Log("We hit something (" + hit.transform.name + ")");
        }
    }

    private void Shoot() {
        GameObject bgo = Instantiate(bullet);
        bgo.transform.position = bulletSpawnPoint.position;
        Vector3 rotation = bgo.transform.rotation.eulerAngles;
        bgo.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bgo.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(bgo, destroyDuration));
    }

    private void Shoot2() {
        RaycastHit hit;
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, distance)) {
            Debug.Log("We hit something (" + hit.transform.name + ")");
        }
    }

    private IEnumerator DestroyBullet(GameObject bullet, float duration) {
        yield return new WaitForSeconds(duration);
        Destroy(bullet);
    }
}
