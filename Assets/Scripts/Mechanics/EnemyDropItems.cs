using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItems : MonoBehaviour
{
    public bool drops;
    public GameObject theDrops;
    public Transform dropItem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<PlayerController>() &&
            collision.contacts[0].normal.y < -0.5f)
        {
            Destroy(gameObject);
            if (drops)
            {
                Instantiate(theDrops, dropItem.position, dropItem.rotation);
            }

        }


    }
}
