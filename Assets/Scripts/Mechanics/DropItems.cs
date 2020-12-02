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

    private void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {

            Debug.Log("works");
            sr.enabled = false;         
            if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
            Destroy(gameObject);

        }
    }
    public void Update()
    {
     
    }

}
