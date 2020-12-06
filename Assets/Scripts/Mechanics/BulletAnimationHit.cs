
﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BulletAnimationHit : MonoBehaviour
{

    void Start(){

	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag =="enemy"){
			other.GetComponent<EnemyController>().HealthDecrement(1);
			Destroy(this.gameObject);
		}
		if (other.tag =="Boss"){
			other.GetComponent<BossController>().HealthDecrement(5);
			Destroy(this.gameObject);
		}
		if (other.tag =="Ground"){
			Destroy(this.gameObject);
		}
	}
}