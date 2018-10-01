using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemy2;

    public float delay = 3f;
    bool hasExploded = false;
    public float radius = 5f;
    public float force = 700;

    public GameObject explosionEffect;

    float countdown;
	// Use this for initialization
	void Start () {
        countdown = delay;

        enemy = GameObject.FindWithTag("Enemy");
        enemy2 = GameObject.FindWithTag("Enemy2");


    }

    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }
		
        void Explode ()
        {
        //show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
          Rigidbody rb =  nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
                
            }
            
        }
        //Get nearby object
        //Add force
        //damage

        //Remove grenade
        Destroy(gameObject);
        }
	}

