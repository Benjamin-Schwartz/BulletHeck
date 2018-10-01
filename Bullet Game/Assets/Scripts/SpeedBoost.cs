using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public GameObject player;
    private GameObject NeedHealth;
    public float speed = 25f;
    public float wait =2f;
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);
    Transform Transform;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Transform = GetComponent<Transform>();
        StartCoroutine (Example());

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
           
            player.GetComponent<Player>().movementSpeed += 5;
            
           
            Destroy(this.gameObject);
            
        }

    }
    IEnumerator Example()
    {
        if (player.GetComponent<Player>().movementSpeed >= 10)
        {
            yield return new WaitForSecondsRealtime(wait);
            Debug.Log("bye");
            player.GetComponent<Player>().movementSpeed = 5;
        }
        
    }
  
}



