using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using Platformer.UI;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        //public AudioClip jumpAudio;
        //public AudioClip respawnAudio;
        //public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;

        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        public float jumpVelocity = 5;

        /*internal new*/
        public Collider2D collider2d;
        public Rigidbody2D rb2d;
        /*internal new*/
        //public AudioSource audioSource;
        public Health health;
        public Mana mana;
        public HealthBar healthBar;
        public ManaBar manaBar;
        public Transform attackPosition;
        public bool controlEnabled = true;
        public bool facingRight = true;

        //change movement to allow addforce to work
        Vector2 move;

        SpriteRenderer spriteRenderer;
        //internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        GameObject donut;

        bool onGround;

        void Awake()
        {
            health = GetComponent<Health>();
            //audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            rb2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            //animator = GetComponent<Animator>();
            donut = GameObject.Find("Donut");
        }

        public void stop()
        {
            move.x = 0;
            
        }

        protected void Update()
        {
            if( rb2d.velocity.y < 0){
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
            }

            if (move.x > 0.01f)
            {
                facingRight = true;
                attackPosition.localPosition = new Vector3(0.5f,0,0);
    
            } else if (move.x < -0.01f) {
                facingRight = false;
                attackPosition.localPosition = new Vector3(-0.5f,0,0);
            }
        }

        public void moveRight()
        {
            //move.x = 1;

            transform.position += transform.right * (Time.deltaTime * 5);
            //rb2d.velocity = new Vector2(5, 0);
        }

        public void moveLeft()
        {
            //move.x = -1;
            transform.position -= transform.right * (Time.deltaTime * 5);
            //rb2d.velocity = new Vector2(-5, 0);
        }

        // public void highJump(){
        //     if (rb2d.velocity.y == 0) {
        //         rb2d.velocity = Vector2.up * jumpVelocity;
        //     }
        // }

        // public void lowJump(){
        //     rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        // }

        public void jump(){
            if(onGround){
                //rb2d.AddForce(new Vector2(0,jumpVelocity), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpVelocity;
                onGround = false;
            }
        }

        public void incrementHealth(int value){
            health.Increment(value);
            healthBar.SetCurrentHealth(health.maxHP, health.currentHP);
        }

        public void decrementHealth(int value){
            health.Decrement(value);
            healthBar.SetCurrentHealth(health.maxHP, health.currentHP);
            if(health.currentHP == 0){
                donut.GetComponent<CharacterSwapping>().onDeathSwitch();
            }
        }

        public void setMaxHealth(int value){
            health.maxHP = value;
            healthBar.SetMaxHealth(health.maxHP, health.currentHP);
        }

        public void incrementMana(int value){
            mana.Increment(value);
            manaBar.SetCurrentMana(mana.maxMP, mana.currentMP);
        }

        public void decrementMana(int value){
            mana.Decrement(value);
            manaBar.SetCurrentMana(mana.maxMP, mana.currentMP);
        }

        public void setMaxMana(int value){
            mana.Decrement(value);
            manaBar.SetMaxMana(mana.maxMP, mana.currentMP);
        }

        // public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
        // {
        //     float timer = 0;
        //     Debug.Log("knocking back");

        //     while (knockbackDuration > timer)
        //     {
        //         timer += Time.deltaTime;
        //         Vector2 direction = (obj.transform.position - gameObject.transform.position).normalized;
        //         rb2d.AddForce(-direction * knockbackPower);
        //     }

        //     yield return 0;
        // }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Ground"))
            {
                onGround = true;
            }
        }
    }
}