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
        if (collision.gameObject.tag == "bullet")
        {
            if (GetComponent<Health>().currentHP >= 20)
            {
                if (drops)
                {
                    Instantiate(theDrops, dropItem.position, dropItem.rotation);
                }

            }

        }


    }
}
