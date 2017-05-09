using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private Vector3 _next;
    public float _currentSeekTime;
    private float _maxSeekTime = 2.5f;
    private float AggroRangeFromPlayer = 3f;
    private float AggroRangeMax = 10f;
    public Bounds _boundingBox;
    private GameObject _currentTarget;
	// Use this for initialization
	void Start ()
    {
        _next = transform.position;
        _boundingBox = new Bounds(transform.position, new Vector3(5, 5));
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(1, 0, 0), Color.red);
        if (_currentTarget == null) Patrol();
        else 
        {
            var distanceToPlayer = Vector2.Distance(transform.position, _currentTarget.transform.position);
            var distanceToTether = Vector2.Distance(transform.position, _boundingBox.center);
            if (distanceToPlayer > AggroRangeFromPlayer || distanceToTether > AggroRangeMax) _currentTarget = null;
            else MoveToCurrentTarget();
        }

	}
    private void MoveToCurrentTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget.transform.position, .02f);
    }
    private void Patrol()
    {
        if (_next == transform.position || _currentSeekTime >= _maxSeekTime)
        {
            _currentSeekTime = 0;
            _next = UnityEngine.Random.insideUnitCircle * UnityEngine.Random.Range(2.0f, 3.0f);
            if (!_boundingBox.Contains(_next))
            {
                _next = _boundingBox.center;
            }
            if (UnityEngine.Random.Range(0, 99) > 50) _next.y = transform.position.y;
            else _next.x = transform.position.x;
        }
        _currentSeekTime += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _next, .01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {
            Debug.Log("hit by player");
        }
    }
    public void SetAggressionTarget(GameObject g)
    {
        if (_currentTarget == null)
        {
            Debug.Log("aggroed!");
            _currentTarget = g;
        }
    }

}
