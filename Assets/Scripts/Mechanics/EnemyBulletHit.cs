using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{
	public int damage = 5;
	GameObject donut;
	CharacterSwapping currentCharacter;
	
    void Start()
    {
        donut = GameObject.Find("Donut");
        currentCharacter = donut.GetComponent<CharacterSwapping>();
    }

	private void OnTriggerEnter2D(Collider2D other){

		if (other.tag =="Player"){
			currentCharacter.currentCharacter.GetComponent<PlayerController>().decrementHealth(damage);
			Destroy(this.gameObject);
		}
		else{}
	}
}