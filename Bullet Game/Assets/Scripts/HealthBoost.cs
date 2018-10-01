using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour {
    public GameObject player;
    private GameObject NeedHealth;
    public float speed = 25f;
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);
    Transform Transform;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        Transform = GetComponent<Transform>();
        
}
	
	// Update is called once per frame
	void Update () {
        Transform.Rotate(rotationVector);


    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health += 10;
            Destroy(this.gameObject);
        }

    }
}
