﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootLeft : MonoBehaviour {
	public float speed = 10.0f;
	public Rigidbody2D rb;
	public Vector2 movement;
	private Vector2 screenBounds;
	void Start(){
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		rb = this.GetComponent<Rigidbody2D>();
	}

	void Update(){
		if(transform.position.x > screenBounds.x * 1.1){
            Destroy(this.gameObject);
        }
		//movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
	}

	
	void FixedUpdate(){
		moveCharacter(movement);
	}

	void moveCharacter(Vector2 direction){
        	//shoots bullet at the right direction
        	rb.MovePosition((Vector2)transform.position + new Vector2(speed * (Time.deltaTime*-1),0f ));
	}
	
}

