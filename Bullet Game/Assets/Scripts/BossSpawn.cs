using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);
    public Vector3 spawnposition;
    public float RandomX;
    public float RandomY;
    public bool isStopCourtine;
    int x;



    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawning());
        StartCoroutine(Terminate());

    }
        // Update is called once per frame
        void Update () {
        transform.Rotate(rotationVector);
        RandomX = Random.Range(1, 50);
        RandomY = Random.Range(1, 50);
        if(x == 3)
        {
            StopCoroutine(Spawning());
        }
    } 
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(2);

        while (x != 3)
        {
            if (!isStopCourtine)
            {
                spawnposition = new Vector3(RandomX, 1, RandomY);
                Instantiate(this.transform, spawnposition, Quaternion.identity);
                x++;
                Debug.Log(x);
                break;
            }
        }
        StartCoroutine(Terminate());
    }
    IEnumerator Terminate()  
    {
        yield return new WaitForSeconds(5);
        isStopCourtine = true;
        StopCoroutine(Spawning());

    }
    
    }

