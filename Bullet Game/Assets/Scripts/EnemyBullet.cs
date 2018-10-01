using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{

    //Variables
    public float speed;
    public float maxDistance;
    public float maxHealth;
    private float health = 0;

    private GameObject triggeringEnemy;
    public float damage;

    private GameObject player;

   // [Header("Unity Stuff")]
   // public Image healthBar;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    //Methods
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
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