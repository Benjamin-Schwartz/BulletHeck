using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWalls : MonoBehaviour {
    //Variables
    public GameObject MegaCube;
    public float WaitTime;
    public float CurrentTime;
    public int SelectedWall =0;
    public int i;

	// Use this for initialization
	void Start () {
        MegaCube = GameObject.FindWithTag("MegaCube");
        //WallSpawn(); 
	}
	
	// Update is called once per frame
	void Update () {
        CurrentTime += 1 * Time.deltaTime;
        if(CurrentTime >= WaitTime)
        {
            SelectedWall++;
            CurrentTime = 0;
        }
        if(SelectedWall > 4)
        {
            SelectedWall = 0;
        }
		
	}
    void WallSpawn()
    {
         i = 0;
        foreach (Transform Wall in transform)
        {
            if (i == SelectedWall)
                Wall.gameObject.SetActive(true);
            else
                Wall.gameObject.SetActive(false);
            i++;

            if (i == SelectedWall)
                Wall.gameObject.SetActive(true);
            else
                Wall.gameObject.SetActive(false);
            i++;

            if (i == SelectedWall)
                Wall.gameObject.SetActive(true);
            else
                Wall.gameObject.SetActive(false);
            i++;

            if (i == SelectedWall)
                Wall.gameObject.SetActive(true);
            else
                Wall.gameObject.SetActive(false);
            i++;

        }


    }
}
