using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        weapon = GameObject.FindWithTag("WeaponHolder");
    }
    public Text ammoText;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().shells == 0)
        {
            ammoText.text = "You need to Reload";
        }
        if (player.GetComponent<Player>().maxShells == 0)
        {
            ammoText.text = "Out of Ammo";
        }

        if (player.GetComponent<Player>().shells > 0 && (player.GetComponent<Player>().maxShells > 0) || (weapon.GetComponent<WeaponSwitch>().pistolDisable == 1) || (player.GetComponent<Player>().shells > 0))
        {
            ammoText.text = "";
        }

    }
}

