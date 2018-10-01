using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthCalc : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
    public Text healthText;
    // Update is called once per frame
    void Update () {
        //healthText.text = "Health:";

    }
}
    

