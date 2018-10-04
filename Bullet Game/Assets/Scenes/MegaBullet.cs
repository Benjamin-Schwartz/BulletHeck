using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBullet : MonoBehaviour
{

    public float speed;
    public float maxDistance;

    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;


        if (maxDistance >= 10)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= 20;
            //healthBar.fillAmount = health / 100f;
            Destroy(this.gameObject);
        }
    }
}

