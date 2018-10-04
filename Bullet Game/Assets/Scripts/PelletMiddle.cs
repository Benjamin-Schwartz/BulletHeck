using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PelletMiddle : MonoBehaviour
{

    //Variables
    public float speed;
    public float maxDistance;
    public float maxHealth;
    private float health = 0;
    public GameObject shooting;

    // [Header("Unity Stuff")]
    // public Image healthBar;

    private GameObject triggeringEnemy;
    public float damage;


    private GameObject player;
    public GameObject bullet;

    private void Start()
    {
        shooting = GameObject.FindWithTag("WeaponHolder");
        player = GameObject.FindWithTag("Player");

    }


    //Methods
    void Update()
    {
        //Stop();
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
  
        maxDistance += 1 * Time.deltaTime;


        if (maxDistance >= .5)
            Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            //healthBar.fillAmount = triggeringEnemy.GetComponent<Enemy>().health / 100;
            Destroy(this.gameObject);



        }
        if (other.tag == "Enemy2")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy2>().health -= damage;
            Destroy(this.gameObject);
        }

        if (other.tag == "MegaCube")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<MegaCube>().health -= damage;
            Destroy(this.gameObject);

        }
        if (other.tag == "BossSpawn")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<BossSpawn>().health -= damage;
            Destroy(this.gameObject);
        }
    }
    public void Stop()
    {
        if (shooting.GetComponent<WeaponSwitch>().pistolDisable == 2)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

    }

}
