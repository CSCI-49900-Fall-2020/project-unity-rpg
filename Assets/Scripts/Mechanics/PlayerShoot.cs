using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
	public bool facingRight = true;
    public float fireRate = 5;
    public float timeToFire = 1;
    public Transform playerEntity;
    public GameObject bulletRightPrefab;
    public GameObject bulletLeftPrefab;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	move.x = Input.GetAxis("Horizontal");
	    if (Input.GetButtonDown ("Fire1") && facingRight)
            bulletShootRight();
            
        if (Input.GetButtonDown ("Fire1") && facingRight==false)    
            bulletShootLeft();
            
		if (move.x > 0.01f)
		    facingRight = true;
        else if (move.x < -0.01f)
            facingRight = false;
    }

    public void bulletShootRight()
    {
        GameObject b = Instantiate(bulletRightPrefab) as GameObject;
        b.transform.position = playerEntity.transform.position;
    }
    public void bulletShootLeft()
    {
        GameObject b = Instantiate(bulletLeftPrefab) as GameObject;
        b.transform.position = playerEntity.transform.position;
    }
}
