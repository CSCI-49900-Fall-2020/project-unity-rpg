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
    public class PlayerController : KinematicObject
    {
        //public AudioClip jumpAudio;
        //public AudioClip respawnAudio;
        //public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
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
        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        //internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        KeyBinds keyBinds;

        void Awake()
        {
            health = GetComponent<Health>();
            //audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            rb2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            //animator = GetComponent<Animator>();
            keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        }

        void stop()
        {
            move.x = 0;
            
        }

        protected override void Update()
        {

            if (controlEnabled)
            {
                
                if (keyBinds.GetButton("Right"))
                {
                    move.x = 1;
                };
                if (keyBinds.GetButton("Left"))
                {
                    move.x = -1;
                };
                
                if (keyBinds.GetButtonUp("Right") || keyBinds.GetButtonUp("Left"))
                {
                    stop();
                };
                
                //move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && keyBinds.GetButtonDown("Jump"))//Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                //else if (Input.GetButtonUp("Jump")) //release jump button
                else if (keyBinds.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    //Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }

            if (move.x > 0.01f)
            {
                facingRight = true;
                attackPosition.localPosition = new Vector3(0.5f,0,0);
    
            } else if (move.x < -0.01f) {
                facingRight = false;
                attackPosition.localPosition = new Vector3(-0.5f,0,0);
            }

            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {

            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        //Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        //Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        void incrementHealth(int value){
            health.Increment(value);
            healthBar.SetCurrentHealth(health.maxHP, health.currentHP);
        }

        void decrementHealth(int value){
            health.Decrement(value);
            healthBar.SetCurrentHealth(health.maxHP, health.currentHP);
        }

        void setMaxHealth(int value){
            health.maxHP = value;
            healthBar.SetMaxHealth(health.maxHP, health.currentHP);
        }

        void incrementMana(int value){
            mana.Increment(value);
            manaBar.SetCurrentMana(mana.maxMP, mana.currentMP);
        }

        void decrementMana(int value){
            mana.Decrement(value);
            manaBar.SetCurrentMana(mana.maxMP, mana.currentMP);
        }

        void setMaxMana(int value){
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

        // private void OnCollisionEnter2D(Collision2D other) {
        //     if(other.gameObject.CompareTag("enemy"))
        //     {
        //         StartCoroutine(Knockback(1, 100, other.gameObject.transform));
        //     }
        // }
        protected override void ComputeVelocity()
        {

            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f){
                spriteRenderer.flipX = false;
            }
            else if (move.x < -0.01f){
                spriteRenderer.flipX = true;
            }

            //animator.SetBool("grounded", IsGrounded);
            //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}