using UnityEngine;
using System.Collections;

public class BowItem : MonoBehaviour, IPlayerItem
{
    // Use this for initialization
    GameObject player;
    private int arrowMAX = 100;
    private int arrowCNT = 100;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public string GetName()
    {
        return "iBow";
    }

    public void UseItem()
    {
        GameObject.Find("ArrowCNT").GetComponent<dfLabel>().Text = arrowCNT.ToString();
    }

    public void ItemFound()
    {
        player.GetComponent<PlayerInventory>().AddItem(this);
        GameObject.FindGameObjectWithTag("iPanel").GetComponent<iPanelUpdate>().SetPanelItemVisible("iBow");
    }



}