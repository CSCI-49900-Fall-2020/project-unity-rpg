
﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BulletAnimationHit : MonoBehaviour
{
	public int damage = 25;

    void Start(){

	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag =="enemy"){
			Debug.Log(damage);
			other.GetComponent<EnemyController>().HealthDecrement(damage);
			Destroy(this.gameObject);
		}
		if (other.tag =="Boss"){
			other.GetComponent<BossController>().HealthDecrement(damage);
			Destroy(this.gameObject);
		}
		if (other.tag =="Ground"){
			Destroy(this.gameObject);
		}
	}
}