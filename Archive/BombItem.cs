using UnityEngine;
using System.Collections;

public class BombItem : MonoBehaviour, IPlayerItem
{
    private GameObject player;
    private int bombMAX = 100;
    private int bombCNT = 100;

    // Use this for initialization
    void Start()
    {
        //fixed
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    // Use this for initialization

    public string GetName()
    {
        return "iBomb";
    }

    public void UseItem()
    {

        GameObject.Find("BombCNT").GetComponent<dfLabel>().Text = bombCNT.ToString();   
    }

    public void ItemFound()
    {
        player.GetComponent<PlayerInventory>().AddItem(this);
        GameObject.FindGameObjectWithTag("iPanel").GetComponent<iPanelUpdate>().SetPanelItemVisible("iBow");
    }
}




