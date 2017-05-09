using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Settings;
using Item;
public class PlayerManager : MonoBehaviour
{
    private GameObject _sword;
    private Dictionary<int, IItem> _inventory = new Dictionary<int, IItem>();
    private int _currentHeading;
    private float _z;
    // Use this for initialization
    void Start()
    {
        _sword = transform.GetChild(0).gameObject;
        _z = transform.position.z;
        var sword = ScriptableObject.CreateInstance<Sword>();
        sword.Init(_sword);
        _inventory[sword.GetId()] = sword;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        if (x != 0) transform.Translate(new Vector3(x * Movement.BaseSpeed, 0, _z));
        if (y != 0) transform.Translate(new Vector3(0, y * Movement.BaseSpeed, _z));
        var dir = Heading.GetDirection(new Vector2(x, y));
        _currentHeading = dir == Heading.NoChange ? _currentHeading : dir;
        if (Input.GetButtonDown("Fire1"))
        {
            _inventory[Item.Db.Sword.Id].Use(_currentHeading);
        }
        foreach (var item in _inventory)
        {
            item.Value.Update();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("hit player");
        }
    }

}
