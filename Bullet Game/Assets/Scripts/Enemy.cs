using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //cube explosion tutorial
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public float explosionRadius;
    public float explosionUpward;
    public float explosionForce;

    float cubesPivotDistance;
    Vector3 cubesPivot;


    //Variables
    public float health;
    public float pointsToGive;
    public float movementSpeed;

    public GameObject player;

    public float waitTime;
    private float currentTime;
    private bool shot;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    private Transform pistolHolder;
    //Methods

    public void Start()
    {
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        player = GameObject.FindWithTag("Player");

        pistolHolder = this.transform.GetChild(0);
        bulletSpawnPoint = pistolHolder.GetChild(2);

        
    }
    public void Update()
    {
        if (!bulletSpawnPoint)
            pistolHolder = this.transform.GetChild(0);
        bulletSpawnPoint = pistolHolder.GetChild(2);

        if (health <= 0)
            //healthBar.fillAmount = health / 100;
        {
            Die();
        }


        this.transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

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
        player.GetComponent<Player>().points += pointsToGive;
    }


    public void explode()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++) { 
            for (int y = 0; y < cubesInRow; y++) { 
                for (int z = 0; z < cubesInRow; z++) {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach(Collider hit in colliders)
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
        piece.GetComponent<Renderer>().material.color = new Color(255, 0,  0);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z)  - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        Destroy(piece, 2);
        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

    }

public void Shoot()
{
    shot = true;

   bulletSpawned =  Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
       bulletSpawned.rotation = this.transform.rotation;
}

    IEnumerator pleaseWork()
    {
        yield return new WaitForSeconds(2); 
    }
}

