using UnityEngine;
using System.Collections;

public class Chest_Open : MonoBehaviour {


    public enum ITEMNAME { Key1, Key2, Key3, Key4, Key5, HeartContainer, Sword, Bow, Arrow, Bomb, Fire, HookShot, Hammer};
    public ITEMNAME Chest_Contents;
    private GameObject player;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<tk2dSprite>().SetSprite(1);
        }
    }



}
