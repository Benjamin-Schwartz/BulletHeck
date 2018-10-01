using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour {
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);
    public Vector3 spawnposition;
    public float RandomX;
    public float RandomY;
    public bool spawn;
    

    // Use this for initialization
    void Start () {
        while (!spawn) { 
            RandomX = Random.Range(1, 50);
        RandomY = Random.Range(1, 50);
        spawnposition = new Vector3(RandomX, 1, RandomY);
            Instantiate(this.transform, spawnposition, Quaternion.identity);
            spawn = true;
            Debug.Log(spawn);
            break;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationVector);
        RandomX = Random.Range(1, 50);
        RandomY = Random.Range(1, 50);
    }
    
}
