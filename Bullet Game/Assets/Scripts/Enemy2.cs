using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy2 : MonoBehaviour
{
    //cube explosion tutorial
    public float cubeSize = 0.2f;
    public int cubesInRow = 3;
    public float explosionRadius;
    public float explosionUpward;
    public float explosionForce;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    //Variables
    public float health;
    public float pointsToGive;
    public float movementSpeed;
    private GameObject triggeringEnemy;

  
    public GameObject player;



    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    private Transform pistolHolder;
    //Methods
    [Header("Unity Stuff")]
    public Image healthBar;


    public void Start()
    {
        player = GameObject.FindWithTag("Player");

    }
    public void Update()
    {
       // healthBar.fillAmount = player.GetComponent<Player>().health;
        
        this.transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if(health <= 0)
            Die();
        



    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Player>().health -= 15;
            //healthBar.fillAmount = triggeringEnemy.GetComponent<Enemy>().health / 100;
            Destroy(this.gameObject);
        }
    }
            public void Die()
    {
        explode();
        
       player.GetComponent<Player>().points += pointsToGive;
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
        piece.GetComponent<Renderer>().material.color = new Color(206, 179, 0);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        Destroy(piece, 2);
        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

    }


}


