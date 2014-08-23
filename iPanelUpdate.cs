using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class iPanelUpdate : MonoBehaviour
{

    public GameObject[] iList;
    private GameObject selection;
    private dfPanel iPanel;
    private PlayerInventory player;
    private bool isPause;
    public bool firstItem = true;
    private int selected = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInventory>();
        iPanel = GetComponent<dfPanel>();
        selection = GameObject.Find("iSelector");
        selection.GetComponent<dfSprite>().enabled = false;
        iPanel.enabled = !iPanel.enabled;

        iList = GameObject.FindGameObjectsWithTag("iPanelItem");
        for (int i = 0; i < iList.Length; i++)
        {
            iList[i].GetComponent<dfSprite>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            iPanel.enabled = !iPanel.enabled;
            Time.timeScale = iPanel.enabled ? 0 : 1;
            isPause = !isPause;
        }

        if (isPause)
        {
            if (!firstItem)
            {
                if (Input.GetButtonDown("Right"))
                {
                    selected = GetNextItem(1);
                    selection.transform.parent = iList[selected].transform;
                    selection.transform.localPosition = Vector3.zero;
                    player.SetEquipped(iList[selected].name);
                }
                if (Input.GetButtonDown("Left"))
                {
                    selected = GetNextItem(-1);
                    selection.transform.parent = iList[selected].transform;
                    selection.transform.localPosition = Vector3.zero;
                    player.SetEquipped(iList[selected].name);
                }
            }
        }
    }

    public int GetNextItem(int direction)
    {
        int current = selected + direction;
        while (current != selected)
        {
            if (current >= iList.Length)
            {
                current = 0;
            }
            else if (current < 0)
            {
                current = iList.Length - 1;
            }

            if (iList[current].GetComponent<dfSprite>().enabled)
            {
                return current;
            }
            current += direction;
        }
        return current;
    }


    public void SetPanelItemVisible(string item)
    {
        for (int i = 0; i < iList.Length; i++)
        {
            if (iList[i].name == item)
            {
                iList[i].GetComponent<dfSprite>().enabled = true;
                if (firstItem)
                {

                    selection.GetComponent<dfSprite>().enabled = true;
                    selection.transform.parent = iList[i].transform;
                    selection.transform.localPosition = Vector3.zero;
                    firstItem = false;
                    player.SetEquipped(item);
                }
                break;
            }
        }

    }

}
