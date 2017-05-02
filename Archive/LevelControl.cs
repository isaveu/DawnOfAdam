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
    public void TitleStartClick(dfControl control, dfMouseEventArgs mouseEvent)
    {
        Application.LoadLevel("Zone_1");
    }
    public void ExitGameClick(dfControl control, dfMouseEventArgs mouseEvent)
    {
        Application.LoadLevel("Title");
    }
    public void TitleStartKeyPress(dfControl control, dfKeyEventArgs keyEvent)
    {
        Debug.Log("Keypressed");
        if (keyEvent.KeyCode == KeyCode.E)
        {
            Debug.Log("E");
            Application.LoadLevel("Zone_1");
        }
    }



}
