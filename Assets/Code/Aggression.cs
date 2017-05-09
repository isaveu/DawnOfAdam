using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggression : MonoBehaviour {

    private EnemyManager _parent;
	// Use this for initialization
	void Start () {
        _parent = transform.parent.GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _parent.SetAggressionTarget(collision.gameObject);
    }
}
