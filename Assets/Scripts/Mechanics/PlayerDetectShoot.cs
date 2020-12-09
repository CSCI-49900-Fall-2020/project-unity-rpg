using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;

public class PlayerDetectShoot : MonoBehaviour
{
    public bool facingRight = true;
    public float timeTemp = 0f;
    public float fireRate = 0.15f;
    public Transform playerEntity;
    public int damage = 5;
    public CharacterSwapping characterS;
    public GameObject donut;
    public GameObject bulletShoot1 = null;
    public GameObject bulletShoot2 = null;
    public GameObject bulletShoot3 = null;
    public GameObject bulletShoot4 = null;
    KeyBinds keyB;
    SkillTree playerSkillTree;
    GameObject bulletShoot = null;
    Vector2 move;

    //       void SelectBullet(int bulletNumber)        determines what bullet gets shot out
    //public void ShootBulletButton(int bulletNumber)   shoot bullet on based on fireRate
    //public void ShootBullet()

    // Start is called before the first frame update
    void Start()
    {

        donut = GameObject.Find("Donut");
        characterS = donut.GetComponent<CharacterSwapping>();
        keyB = donut.GetComponent<KeyBinds>();
        playerSkillTree = donut.GetComponent<SkillTree>();
        
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

    void ScriptBullet()
    {
        int bonusDamage = 0;
        for (int i = 0; i < playerSkillTree.sTree.Length; i++)
        {
            if (playerSkillTree.sTree[i].skilButtonID == "f1" && playerSkillTree.sTree[i].abilityLevel >= 1)
            {
                bonusDamage += 1 * playerSkillTree.sTree[i].abilityLevel;
            }
            if (playerSkillTree.sTree[i].skilButtonID == "f2" && playerSkillTree.sTree[i].abilityLevel >= 1)
            {
                bonusDamage += 2 * playerSkillTree.sTree[i].abilityLevel;
            }
            if (playerSkillTree.sTree[i].skilButtonID == "f3" && playerSkillTree.sTree[i].abilityLevel >= 1)
            {
                bonusDamage += 3 * playerSkillTree.sTree[i].abilityLevel;
            }
            if (playerSkillTree.sTree[i].skilButtonID == "f4" && playerSkillTree.sTree[i].abilityLevel >= 1)
            {
                bonusDamage += 4 * playerSkillTree.sTree[i].abilityLevel;
            }
        }

        GameObject bullet = Instantiate(bulletShoot) as GameObject;
        bullet.transform.position = playerEntity.transform.position;
        bullet.GetComponent<BulletAnimationHit>().damage = characterS.currentCharacter.GetComponent<PlayerDetectShoot>().damage + bonusDamage;
        
    }

    public void ShootBullet()
    {
        if (bulletShoot == null){
            print("shot empty");
        }
        else if (keyB.GetButton("Up") && keyB.GetButton("Right"))
        {
            //UR means upper right direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 8;
            ScriptBullet();
        }
        else if (keyB.GetButton("Up") && keyB.GetButton("Left"))
        {
            //UL means upper left direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 7;
            ScriptBullet();
        }
        else if (keyB.GetButton("Up"))
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 6;
            ScriptBullet();
        }


        else if (keyB.GetButton("Down") && keyB.GetButton("Right"))
        {
            //DR means lower right direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 5;
            ScriptBullet();
        }
        else if (keyB.GetButton("Down") && keyB.GetButton("Left"))
        {
            //DL means lower left direction
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 4;
            ScriptBullet();
        }
        else if (keyB.GetButton("Down"))
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 3;
            ScriptBullet();
        }


        else if ( facingRight )
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 2;
            ScriptBullet();
        }
        else if ( facingRight == false )    
        {
            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 1;
            ScriptBullet();
        }
    }
}
