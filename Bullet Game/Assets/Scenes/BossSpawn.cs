using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{

    //Explosion

    public float cubeSize = 1f;
    public int cubesInRow = 5;
    public float explosionRadius;
    public float explosionUpward;
    public float explosionForce;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float speed = 10f;
    public float health;


    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;
    public Transform bulletSpawnPoint4;
    private Transform bulletSpawned;
    public GameObject bullet;
    public bool shot;
    public float waitTime;
    private float currentTime;

    //gameObjects
    public GameObject player;
    public GameObject Megacube;
    private int pointsToGive = 100;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Megacube = GameObject.FindWithTag("MegaCube");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        shooting();

        if (health <= 0)

        {
            Die();
        }
    }

    public void Shoot()
    {
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint1.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;

        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint2.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;

        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint3.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;

        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint4.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }

    public void shooting()
    {
        if (currentTime == 0)
            Shoot();

        if (shot && currentTime < waitTime)
            currentTime += 1 * Time.deltaTime;

        if (currentTime >= waitTime)
            currentTime = 0;

    }

    public void Die()
    {
        explode();
       // player.GetComponent<Player>().points += pointsToGive;
        Megacube.GetComponent<MegaCube>().count -= 1;
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
        piece.GetComponent<Renderer>().material.color = new Color(255, 0, 0);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        Destroy(piece, 2);
        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

    }
}


