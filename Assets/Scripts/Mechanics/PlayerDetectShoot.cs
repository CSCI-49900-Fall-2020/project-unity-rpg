using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class PlayerDetectShoot : MonoBehaviour
{
    public bool facingRight = true;
    public float timeTemp = 0f;
    public float fireRate = 0.15f;
    public Transform playerEntity;
    public int damage;

    public GameObject bulletShoot1 = null;
    public GameObject bulletShoot2 = null;
    public GameObject bulletShoot3 = null;
    public GameObject bulletShoot4 = null;

    GameObject bulletShoot = null;
    Vector2 move;

    //       void SelectBullet(int bulletNumber)        determines what bullet gets shot out
    //public void ShootBulletButton(int bulletNumber)   shoot bullet on based on fireRate
    //public void ShootBullet()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        if (move.x > 0.01f)
            facingRight = true;
        else if (move.x < -0.01f)
            facingRight = false;
        //if (Input.GetKey ("/") && Time.time > timeTemp)
    }

    void SelectBullet(int bulletNumber){
        switch (bulletNumber){
            case 1:
                bulletShoot = bulletShoot1;

                break;
            case 2:
                bulletShoot = bulletShoot2;
                break;
            case 3:
                bulletShoot = bulletShoot3;
                break;
            case 4:
                bulletShoot = bulletShoot4;
                break;
        }
    }

    public void ShootBulletButton(int bulletNumber)
    {
        if (Time.time > timeTemp)
        {
            SelectBullet(bulletNumber);
            ShootBullet();
            timeTemp = Time.time + fireRate;
        }
    }



    public void ShootBullet()
    {
        if (bulletShoot == null){
            print("shot empty");
        }
        else if (Input.GetKey("w") && Input.GetKey("d"))
        {
            //UR means upper right direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 8;
            GameObject bulletUR = Instantiate(bulletShoot) as GameObject;
            bulletUR.transform.position = playerEntity.transform.position;          
        }
        else if (Input.GetKey("w") && Input.GetKey("a"))
        {
            //UL means upper left direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 7;
            GameObject bulletUL = Instantiate(bulletShoot) as GameObject;
            bulletUL.transform.position = playerEntity.transform.position;  
        }
        else if (Input.GetKey("w"))
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 6;
            GameObject bulletUp = Instantiate(bulletShoot) as GameObject;
            bulletUp.transform.position = playerEntity.transform.position;
        }


        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            //DR means lower right direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 5;
            GameObject bulletDR = Instantiate(bulletShoot) as GameObject;
            bulletDR.transform.position = playerEntity.transform.position; 
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            //DL means lower left direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 4;
            GameObject bulletDL = Instantiate(bulletShoot) as GameObject;
            bulletDL.transform.position = playerEntity.transform.position;  
        }
        else if (Input.GetKey("s"))
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 3;
            GameObject bulletDown = Instantiate(bulletShoot) as GameObject;
            bulletDown.transform.position = playerEntity.transform.position;
        }


        else if ( facingRight )
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 2;
            GameObject bulletR = Instantiate(bulletShoot) as GameObject;
            bulletR.transform.position = playerEntity.transform.position;      
        }
        else if ( facingRight == false )    
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 1;
            GameObject bulletL = Instantiate(bulletShoot) as GameObject;
            bulletL.transform.position = playerEntity.transform.position;
        }
    }
}
