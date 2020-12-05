
﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BulletAnimationHit : MonoBehaviour
{

	//public Animator animator;
	
    void Start(){
    //	animator.SetBool("hitConfirm", false);
	}
    // Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag =="enemy"){
	//		animator.SetBool("hitConfirm",true);
			other.GetComponent<Health>().Decrement(15);
			Destroy(this.gameObject);
		}
		if (other.tag =="Boss"){
	//		animator.SetBool("hitConfirm",true);
			other.GetComponent<Health>().Decrement(15);
			Destroy(this.gameObject);
		}
		if (other.tag =="Ground"){
	//		animator.SetBool("hitConfirm",true);
			Destroy(this.gameObject);
		}
	}
}