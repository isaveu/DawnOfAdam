using UnityEngine;
using System.Collections;

public class ChestOpen : MonoBehaviour
{
    public GameObject contentsPrefab;
    private bool isOpened = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isOpened)
        {
            GetComponent<tk2dSprite>().SetSprite(1);
            StartCoroutine(AcquireItem());
        }
    }

    IEnumerator AcquireItem()
    {
        isOpened = true;
        Instantiate(contentsPrefab, new Vector3(transform.position.x + .05f, transform.position.y + .31f, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(1f);
    }

}
