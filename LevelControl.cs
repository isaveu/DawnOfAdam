using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TitleStart_Click(dfControl control, dfMouseEventArgs mouseEvent)
    {
        Application.LoadLevel("Zone_1");
    }
    public void ExitGame_Click(dfControl control, dfMouseEventArgs mouseEvent)
    {
        Application.LoadLevel("Title");
    }
    public void TitleStart_KeyPress(dfControl control, dfKeyEventArgs keyEvent)
    {
        Debug.Log("Keypressed");
        if (keyEvent.KeyCode == KeyCode.E)
        {
            Debug.Log("E");
            Application.LoadLevel("Zone_1");
        }
    }



}
