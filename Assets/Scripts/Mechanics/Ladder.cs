using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isClimbing = false;
    public float climbSpeed = 5f;

    void OnTriggerStay2D(Collider2D other) {
        Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();

        if(other.tag == "Player" && Input.GetKey(KeyCode.W)){
            otherRb2d.velocity = new Vector2(0,climbSpeed);
            isClimbing = true;
        } else if(other.tag == "Player" && Input.GetKey(KeyCode.S)){
            otherRb2d.velocity = new Vector2(0,-climbSpeed);
            isClimbing = true;
        } else {
            if(isClimbing){
                otherRb2d.gravityScale = 0;
                otherRb2d.velocity = new Vector2(0,0);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            isClimbing = false;
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
