using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Gameplay;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    PlayerController player;
    GameObject donut;
    CharacterSwapping currentChar;

    void Start()
    {
        donut = GameObject.Find("Donut");
        //player = currentChar.currentCharacter;
        currentChar = donut.GetComponent<CharacterSwapping>();
    }

    //Note: right now, there is no way to avoid the attack
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Debug.Log("Attack");
        //Debug.Log(currentChar.currentCharacter.name); //gives current character name (works)
        //if (colInfo != null)
        //{
        //    //colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        //}
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        //currentChar.currentCharacter.GetComponent<PlayerController>().decrementHealth(attackDamage); //decrements current player health (works)
        //if (colInfo != null)
        //{
        //    Debug.Log("Attack");
        //    //colInfo[i].GetComponent<PlayerController>().decrementHealth(attackDamage);
        //    //player.decrementHealth(attackDamage);
        //}
    }
}