using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCube : MonoBehaviour {
    public float health;
    public float pointsToGive;
    public float movementSpeed;
    public float waitTime;
    private float currentTime;

    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    public GameObject bullet;
    public bool shot;

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (currentTime == 0)
            Shoot();

        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;

        if (currentTime >= waitTime)
            currentTime = 0;
    }




public void Shoot()
    {
        shot = true;

        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }
}
