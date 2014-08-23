using UnityEngine;
using System.Collections;



public class PlayerMovement : MonoBehaviour
{
    private tk2dSprite sprite;
    private PLAYERHEADING direction;
    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<tk2dSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = Vector2.zero;
        KeyPressIsMovement();
    }
    
    public PLAYERHEADING GetDirection()
    {
        return direction;
    }

    void KeyPressIsMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            if (y > 0)
            {
                sprite.SetSprite(6);
                direction = PLAYERHEADING.Up;
            }
            else if (y < 0)
            {
                sprite.SetSprite(7);
                direction = PLAYERHEADING.Down;
            }
            else if (x < 0)
            {
                sprite.SetSprite(1);
                direction = PLAYERHEADING.Left;
            }
            else if (x > 0)
            {
                sprite.SetSprite(3);
                direction = PLAYERHEADING.Right;
            }
            rigidbody2D.velocity = new Vector2(x, y);
        }
    }
}
