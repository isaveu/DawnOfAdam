using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{

    public enum Direction { Up, Down, Left, Right };
    public Direction Current_Direction;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.zero;
        KeyPressIsMovement();
    }

    void KeyPressIsMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            if (y > 0)
            {
                Current_Direction = Direction.Up;
            }
            else if (x < 0)
            {
                Current_Direction = Direction.Left;
            }
            else if (y < 0)
            {
                Current_Direction = Direction.Down;
            }
            else if (x > 0)
            {
                Current_Direction = Direction.Right;
            }
            rigidbody2D.velocity = new Vector2(x, y);
            Update_Sprite();
        }

    }

    void Update_Sprite()
    {
        if (Current_Direction == Direction.Left)
        {
            GetComponent<tk2dSprite>().SetSprite(1);
        }
        else if (Current_Direction == Direction.Right)
        {
            GetComponent<tk2dSprite>().SetSprite(3);
        }
        else if (Current_Direction == Direction.Up)
        {
            GetComponent<tk2dSprite>().SetSprite(6);
        }
        else if (Current_Direction == Direction.Down)
        {
            GetComponent<tk2dSprite>().SetSprite(7);
        }
    }

}
