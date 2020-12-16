using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;
    private SpriteRenderer sr;
    public int numberOfHits = 0;

    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            numberOfHits--;
            if (numberOfHits == 0)
            {
                Debug.Log("works");
                sr.enabled = false;
                if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);

        }
    }
    public void Update()
    {

    }

}
