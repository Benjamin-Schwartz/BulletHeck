using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaCube : MonoBehaviour
{

    [Header("Explosion")]
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public float explosionRadius;
    public float explosionUpward;
    public float explosionForce;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float health;
    public float startHealth = 5000;
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
        if (health <= 2500)
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
        if (health <= 2500 && !spawning)
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
        if(health <= 0)
        {
            Die();
        }
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
       // transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

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
    void Die()
    {
        explode();
    }
        public void explode()
        {
            gameObject.SetActive(false);

            for (int x = 0; x < cubesInRow; x++)
            {
                for (int y = 0; y < cubesInRow; y++)
                {
                    for (int z = 0; z < cubesInRow; z++)
                    {
                        createPiece(x, y, z);
                    }
                }
            }

            //get explosion position
            Vector3 explosionPos = transform.position;

            //get colliders in that position and radius
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            //add explosion force to all colliders in that overlap sphere
            foreach (Collider hit in colliders)
            {
                //get rigidbody from collider object
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    //add explosion force to this body with given  parameters
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
                }
            }
        }
        void createPiece(int x, int y, int z)
        {
            //create piece
            GameObject piece;

            piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
            piece.GetComponent<Renderer>().material.color = new Color(0, 0, 0);

            //set piece position and scale
            piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
            piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
            Destroy(piece, 2);
            //add rigidbody and set mass
            piece.AddComponent<Rigidbody>();
            piece.GetComponent<Rigidbody>().mass = cubeSize;

        }

    }


