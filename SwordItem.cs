using UnityEngine;
using System.Collections;

public class SwordItem : MonoBehaviour, IPlayerItem
{
    // Use this for initialization
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(HidePickup());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UseItem()
    {
        gameObject.SetActive(true);
        StartCoroutine(Swing());
    }

    public void ItemFound()
    {
        player.GetComponent<PlayerInventory>().AddItem(this);
        GameObject.FindGameObjectWithTag("iPanel").GetComponent<iPanelUpdate>().SetPanelItemVisible("iBow");
    }

    IEnumerator HidePickup()
    {
        yield return new WaitForSeconds(1f);
        transform.parent = player.transform;
        gameObject.SetActive(false);
    }


    IEnumerator Swing()
    {

        PLAYERHEADING direction = player.GetComponent<PlayerMovement>().GetDirection();
        GetComponent<tk2dSprite>().SortingOrder = 1;
        if (direction == PLAYERHEADING.Up)
        {
            GetComponent<tk2dSprite>().SortingOrder = 0;
            transform.localPosition = new Vector3(.1f, .15f, transform.localPosition.z);
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        else if (direction == PLAYERHEADING.Down)
        {
            transform.localPosition = new Vector3(-.17f, -.12f, transform.localPosition.z);
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        else if (direction == PLAYERHEADING.Left)
        {
            transform.localPosition = new Vector3(-.1f, .08f, transform.localPosition.z);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        else if (direction == PLAYERHEADING.Right)
        {
            transform.localPosition = new Vector3(.1f, -.12f, transform.localPosition.z);
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }

        yield return new WaitForSeconds(.15f);
        gameObject.SetActive(false);
    }

    public string GetName()
    {
        return "iSword";
    }
}
