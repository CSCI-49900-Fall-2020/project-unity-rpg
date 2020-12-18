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
        currentChar = donut.GetComponent<CharacterSwapping>();
    }

    //Note: right now, there is no way to avoid the attack
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null)
        {
            currentChar.currentCharacter.GetComponent<PlayerController>().decrementHealth(attackDamage);
        }
    }
}