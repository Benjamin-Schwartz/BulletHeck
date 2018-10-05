using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Explosion")]
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public float explosionRadius;
    public float explosionUpward;
    public float explosionForce;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    //Variables
    public float movementSpeed;
    public GameObject camera;

    public GameObject playerObj;

    public float waitTime;
    private float currentTime;
    public GameObject bulletSpawnPoint;
    public GameObject pelletSpawn;
    public bool shot;
   
    public GameObject bullet;
    public GameObject pellet;
    public GameObject pelletMid;
    public GameObject pelletLeft;

    Vector3 peelit = new Vector3(0f, 0f, 0f);

    private Transform pelletSpawned;
    private Transform bulletSpawned;

    private Transform grenadeSpawned;
    public GameObject grenade;
    public float Grenades = 1;

    public float points;
    public float health;
    public float maxHealth;
    public bool bossfight = true;

    //stop pistol from shooting
    public GameObject shooting;

    [Header("Health stuff")]
    public Image healthBar;

    public GameObject enemy;

    //shooting
    public int shells = 0;
    public int maxShells = 24;
    public int pistolAmmo = 0;
    public int shots;
    public int total;
    //Methods

    void Start()
    {
        shooting = GameObject.FindWithTag("WeaponHolder");
        enemy = GameObject.FindWithTag("Enemy");
        shells = 12;
        health = maxHealth;
    }
    void Update()
    {

        healthBar.fillAmount = health / 100;
        //Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //Player Movement
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);

        if (playerObj.transform.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetKey(KeyCode.T))
        {
            KillAll();
        }

            //Shooting
            if (Input.GetMouseButtonDown(0))
        {

            if (currentTime == 0)
                Shoot();

            if (shot && currentTime < waitTime)
                currentTime += 1 * Time.deltaTime;

            if (currentTime >= waitTime)
                currentTime = 0;
        }
        

        if (Input.GetKey(KeyCode.G) && Grenades > 0)
        {
            Grenade();
        }
        if (health <= 0)
            Die();



        //reloading

        if (maxShells < 0)
        {
            maxShells = 0;
        }

        if (Input.GetKey(KeyCode.R))
        {
            total = maxShells + shells;
            if (maxShells >= 12)
            {
                shells = 12;
            }
            if (maxShells < 12 && total >= 12)
            {
                shells = 12;
            }
            if (maxShells + shells < 12)
            {

                shells = maxShells + shells;
                maxShells = 0;
            }

            maxShells = maxShells - shots;
            shots = 0;
        }
        if(points >= 1000 && bossfight)
        {
            bossfight = false;
            if (!bossfight)
            {
                SceneManager.LoadScene("Boss");
            }
            bossfight = true;
        }
    }


    void Shoot()
    {
        shot = true;

        if (shooting.GetComponent<WeaponSwitch>().pistolDisable == 1)
        {
            bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
            bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
        }
        if (shooting.GetComponent<WeaponSwitch>().pistolDisable == 2 && shells > 0)
        {
            pelletSpawned = Instantiate(pellet.transform, pelletSpawn.transform.position, Quaternion.identity);
            pelletSpawned.rotation = pelletSpawn.transform.rotation;

            pelletSpawned = Instantiate(pelletMid.transform, pelletSpawn.transform.position, Quaternion.identity);
            pelletSpawned.rotation = pelletSpawn.transform.rotation;

            pelletSpawned = Instantiate(pelletLeft.transform, pelletSpawn.transform.position, Quaternion.identity);
            pelletSpawned.rotation = pelletSpawn.transform.rotation;

            shells--;
            shots++;
        }
    }

    void Grenade()
    {

        grenadeSpawned = Instantiate(grenade.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        grenadeSpawned.rotation = bulletSpawnPoint.transform.rotation;
        Grenades--;
    }
    public void Die()
    {
        explode();
        FindObjectOfType<GameManager>().EndGame();

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

    public void KillAll()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
           // Destroy(go);
                  
        }
    }
}

    
        

    
        