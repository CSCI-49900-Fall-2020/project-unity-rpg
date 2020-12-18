using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;

namespace Platformer.Mechanics
{
	public class EnemyDetectShoot : MonoBehaviour
	{
	    public bool facingRight = true;
	    public float timeTemp = 0f;
	    public float fireRate = 1f;
	    public Transform enemyEntity;
	    public int direction = 3;

	    public GameObject bulletShoot = null;
	    Vector2 move;

	    //public void ShootBulletButton()   shoot bullet on based on fireRate

	    // Start is called before the first frame update
	    void Start()
	    {

	    }

	    // Update is called once per frame
	    void Update()
	    {
	    	ShootBulletButton();
	    }

	    public void ShootBulletButton()
	    {
	    	if (bulletShoot != null)
	    	{
		        if(Time.time > timeTemp)
		        {
		            bulletShoot.GetComponent<Player8Shoot>().bulletDirection = direction;
		            GameObject bullet = Instantiate(bulletShoot) as GameObject;
		        	bullet.transform.position = enemyEntity.transform.position;
		            timeTemp = Time.time + fireRate;
		        }
		    }
	    }
	    //UR means upper right direction
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 8;
	    //UL means upper left direction
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 7;
		//shoots up
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 6;

	    //DR means lower right direction
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 5;
	    //DL means lower left direction
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 4;
		//shoots down
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 3;

	    //shoots right
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 2;
	    //shoots left
	    //bulletShoot.GetComponent<Player8Shoot>().bulletDirection = 1;
	}
}