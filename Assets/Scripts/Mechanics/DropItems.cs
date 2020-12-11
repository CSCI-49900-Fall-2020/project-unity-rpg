using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;
    public SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        
        if (sr == false)
        { 
            if (drops) Instantiate(theDrops,dropPoint.position,dropPoint.rotation);
        }
    }

}
