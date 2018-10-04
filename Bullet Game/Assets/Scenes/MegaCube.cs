using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaCube : MonoBehaviour
{
    public float health;
    public float startHealth = 100;
    public float pointsToGive;
    public float movementSpeed;
    public float waitTime;
    private float currentTime;


    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    public GameObject bullet;
    public bool shot;

    //Boss Spawn
    public GameObject BossSpawn;
    public Vector3 spawnposition;
    private Transform BossSpawned;
    public bool spawning = false;
    public bool shotz;
    public Image BossHealthBar;

    public float count;

    public GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        BossSpawn = GameObject.FindWithTag("BossSpawn");
        health = startHealth;
        if (health <= 8000)
        {
            Spawn();//Look and follow player and shoot
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shotz)
        {
            shooting();

        }
        if (health <= 8000 && !spawning)
        {
            Spawn();//Look and follow player and shoot
            spawning = true;
            shotz = false;

        }

        if (count <= 0)
        {
            shotz = true;
        }
        BossHealthBar.fillAmount = health / startHealth;
    }

    public void Shoot()
    {
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }

    public void shooting()
    {
        this.transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (currentTime == 0)
            Shoot();

        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;

        if (currentTime >= waitTime)
            currentTime = 0;
    }

    public void Spawn()
    {



        spawnposition = new Vector3(0, 1, 19);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);

        spawnposition = new Vector3(0, 1, -19);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);

        spawnposition = new Vector3(30, 1, 9);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(-30, 1, 9);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(15, 1, -6);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(-15, 1, -6);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(30, 1, 40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(-30, 1, 40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(30, 1, -40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(-30, 1, -40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(0, 1, 40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);
        spawnposition = new Vector3(0, 1, -40);
        Instantiate(BossSpawn.transform, spawnposition, Quaternion.identity);

        count = 12;
        // BossDuringSpawn();

    }
    public void BossDuringSpawn()
    {

        transform.GetComponent<Renderer>().enabled = false;

        Instantiate(this.gameObject.transform, new Vector3(0, 0, 0), Quaternion.identity);
        transform.GetComponent<Renderer>().enabled = true;
    }

}
