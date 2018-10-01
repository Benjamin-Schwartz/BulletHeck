using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private GameObject NeedHealth;
    public float speed = 25f;
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);
    Transform Transform;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        Transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Transform.Rotate(rotationVector);


    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
             player.GetComponent<Player>().maxShells += 24;
            player.GetComponent<Player>().Grenades += 1;
            Destroy(this.gameObject);
           


        }

    }


}
