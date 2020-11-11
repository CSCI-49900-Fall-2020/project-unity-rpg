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

    public GameObject bulletShoot;
    Vector2 move;

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

    public void ShootBulletButton()
    {
        if (Time.time > timeTemp)
        {
            ShootBullet();
            timeTemp = Time.time + fireRate;
        }
    }

    public void ShootBullet()
    {
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            //donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 8;
            Quaternion rotation = Quaternion.Euler(0,0,45);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletUR = Instantiate(bulletShoot) as GameObject;
            bulletUR.transform.position = playerEntity.transform.position;     
            //bulletUR.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;         
        }
        else if (Input.GetKey("w") && Input.GetKey("a"))
        {
            //donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 7;
            Quaternion rotation = Quaternion.Euler(0,0,135);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletUL = Instantiate(bulletShoot) as GameObject;
            bulletUL.transform.position = playerEntity.transform.position;  
            //bulletUL.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;
        }
        else if (Input.GetKey("w"))
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection =6;
            Quaternion rotation = Quaternion.Euler(0,0,90);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletUp = Instantiate(bulletShoot) as GameObject;
            bulletUp.transform.position = playerEntity.transform.position;
            //bulletUp.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;
        }


        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 5;
            Quaternion rotation = Quaternion.Euler(0,0,-45);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletDR = Instantiate(bulletShoot) as GameObject;
            bulletDR.transform.position = playerEntity.transform.position; 
            //bulletDR.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position; 
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection = 4;
            Quaternion rotation = Quaternion.Euler(0,0,-135);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletDL = Instantiate(bulletShoot) as GameObject;
            bulletDL.transform.position = playerEntity.transform.position; 
            //bulletDL.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position; 
        }
        else if (Input.GetKey("s"))
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection =3;
            Quaternion rotation = Quaternion.Euler(0,0,-90);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletDown = Instantiate(bulletShoot) as GameObject;
            bulletDown.transform.position = playerEntity.transform.position;
            //bulletDown.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;
        }


        else if ( facingRight )
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection =2;
            Quaternion rotation = Quaternion.Euler(0,0,0);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletR = Instantiate(bulletShoot) as GameObject;
            bulletR.transform.position = playerEntity.transform.position;
            //bulletR.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;
              
        }
        else if ( facingRight == false )    
        {
            bulletShoot.GetComponent<Player5Shoot>().bulletDirection =1;
            Quaternion rotation = Quaternion.Euler(180,0,180);
            bulletShoot.GetComponent<Transform>().rotation = rotation;
            GameObject bulletL = Instantiate(bulletShoot) as GameObject;
            bulletL.transform.position = playerEntity.transform.position;
            //bulletL.transform.position = gameObject.GetComponent<CharacterSwapping>().currentCharacter.transform.position;
        }
    }
}
