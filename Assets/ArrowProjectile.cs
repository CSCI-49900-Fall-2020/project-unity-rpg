using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
public class ArrowProjectile : MonoBehaviour
{

    public GameObject bulletShoot;
    public Transform objectEntity;
    public float tempTimer = 0f;
    public float fireRate = 0.15f;

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= tempTimer)
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 2;   //shoots right
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 1;   //shoots left
            GameObject bulletUR = Instantiate(bulletShoot) as GameObject;
            bulletUR.transform.position = objectEntity.transform.position;
            tempTimer += Time.time + fireRate;
        }
    }
}
