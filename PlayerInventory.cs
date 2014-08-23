using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerInventory : MonoBehaviour
{

    private IPlayerItem equipped;
    private List<IPlayerItem> inventory = new List<IPlayerItem>();
    public float playerHP = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (equipped != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                equipped.UseItem();
            }
        }
    }

    public void AddItem(IPlayerItem newItem)
    {

        inventory.Add(newItem);
        Debug.Log(newItem + " added");
    }

    public float GetHealth()
    {
        return playerHP;
    }

    public void SetEquipped(string select)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].GetName() == select)
            {
                Debug.Log(inventory[i].GetName() + " is equipped");
                equipped = inventory[i];
            }
        }
    }

}