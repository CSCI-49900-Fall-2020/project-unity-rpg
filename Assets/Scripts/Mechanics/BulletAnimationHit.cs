
﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BulletAnimationHit : MonoBehaviour
{

	public Animator animator;
	
    void Start(){
    	animator.SetBool("hitConfirm", false);
	}
    // Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag =="enemy"){
			animator.SetBool("hitConfirm",true);
			//Destroy(this.gameObject);

			other.GetComponent<Collider2D>().gameObject.GetComponent<Health>().Decrement(2);
		}
	}


}