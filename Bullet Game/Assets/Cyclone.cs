using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclone : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject Megacube;

    public bool Turn;

    // Use this for initialization
    void Start()
    {
        Turn = true;
        player = GameObject.FindWithTag("Player");
        Megacube = GameObject.FindWithTag("MegaCube");
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
        if (Megacube.GetComponent<MegaCube>().health <= 2500)
        {
            Turn = false;
        }
        if (Megacube.GetComponent<MegaCube>().count == 0)
        {
            Turn = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= 20;


        }
    }
    void Spin()
    {
        while (Turn)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}

