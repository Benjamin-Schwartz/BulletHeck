using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public int selectedWeapon = 0;
    public float health;
    public float pistolDisable = 1;
    public GameObject bullet;
    // Use this for initialization
    void Start () { 
        selectedWeapon = 0;
        SelectWeapon();
        
    }
	
	// Update is called once per frame
	void Update () {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            pistolDisable = 1;
            selectedWeapon = 0;
           
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }
        
        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }


    }
    
    void SelectWeapon()
    {
        pistolDisable = 1;
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                 weapon.gameObject.SetActive(true);
                pistolDisable = selectedWeapon;
            }
            else
                weapon.gameObject.SetActive(false);
            pistolDisable = selectedWeapon+1;
            i++;
        }
    }      
}
