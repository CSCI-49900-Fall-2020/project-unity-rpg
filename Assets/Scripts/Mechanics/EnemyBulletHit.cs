using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{
	public int damage = 5;

    void Start()
    {

    }

	private void OnTriggerEnter2D(Collider2D other){

		if (other.tag =="Player"){
			other.gameObject.GetComponent<PlayerController>().decrementHealth(damage);
			Destroy(this.gameObject);
		}
		else{}
	}
}