using UnityEngine;
using System.Collections;

public class BombEffect : MonoBehaviour {
   
    public GameObject explosion; //connect particle component
    public GameObject wick; // connect particle component
    private Vector3 startPos;
    private float timer = 3f;
    // Use this for initialization
    void Start()
    {
        transform.Translate(.5f, 0, 0);
        startPos = transform.position;
        explosion.SetActive(false);
        explosion.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
            explosion.SetActive(true);
            Destroy(explosion, .2f);
        }
    }
}
