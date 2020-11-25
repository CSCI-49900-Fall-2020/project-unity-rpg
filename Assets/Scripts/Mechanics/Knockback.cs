using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // Start is called before the first frame update
    public float explosionStrength = 5.0f;
    public Collider2D target;
    public Vector2 forceVec;
    public Rigidbody2D rb2d;
    void Start()
    {
        target = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        forceVec = new Vector2 (target.GetComponent<Rigidbody2D>().velocity.normalized.x * explosionStrength, target.GetComponent<Rigidbody2D> ().velocity.normalized.y * explosionStrength);
    }

    // Update is called once per frame
    
    
    void Update()
    {
        if(Input.GetKeyDown("m")){
            if(gameObject.CompareTag("enemy")){
                //gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                Debug.Log("pushing");
                //rb2d.AddForce(forceVec,ForceMode2D.Force);
                //rb2d.AddForce(transform.forward * 500, ForceMode2D.Impulse);
                //gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                //rb2d.velocity = new Vector2 (0,5);
                rb2d.AddForce(new Vector2 (5,5), ForceMode2D.Impulse);
                //rb2d.AddForce(new Vector2 (0,5), ForceMode2D.Force);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player")){
            if(other.gameObject.CompareTag("enemy")){
                Debug.Log("OnTrigerEnter2D");
                gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 5, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(gameObject.CompareTag("enemy")){
            if(other.gameObject.CompareTag("enemy")){
                Debug.Log("Hit ally");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5, ForceMode2D.Impulse);
                gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 5, ForceMode2D.Impulse);
            }
        }
    }
}
