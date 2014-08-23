using UnityEngine;
using System.Collections;

public class HPUpdate : MonoBehaviour {

    private PlayerInventory inventory;
	// Use this for initialization
	void Start () 
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<dfSprite>().FillAmount = inventory.GetHealth() / 10; 
	}
}
