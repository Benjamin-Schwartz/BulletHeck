using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour {
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Use this for initialization
    //private float score = Player.GetComponent<Player>().health;
    public Text scoreText;

    // Update is called once per frame
    void Update () {
        scoreText.text = "Score: " + player.GetComponent<Player>().points;


    }
}
