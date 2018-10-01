using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * Time.deltaTime * 2);
        Example();
        transform.Translate(Vector3.forward * Time.deltaTime * 2);

    }
    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(2);
       
    }
}
