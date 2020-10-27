﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public bool facingRight = true;
        public float fireRate = 5;
        public float timeToFire = 1;
        public Transform playerEntity;
        public GameObject bulletRightPrefab;
        public GameObject bulletLeftPrefab;
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

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
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;
        KeyBinds keyBinds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
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
                if (keyBinds.GetButtonDown("Right"))
                {
                    move.x = 1;
                }
                if (keyBinds.GetButtonDown("Left"))
                {
                    move.x = -1;
                }
                
                if (keyBinds.GetButtonUp("Right") || keyBinds.GetButtonUp("Left"))
                {
                    stop();
                }
                
                //move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && keyBinds.GetButtonDown("Jump"))//Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                //else if (Input.GetButtonUp("Jump")) //release jump button
                else if (keyBinds.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }

                if (Input.GetButtonDown("Fire1") && facingRight)
                    bulletShootRight();

                if (Input.GetButtonDown("Fire1") && facingRight == false)
                    bulletShootLeft();
            }
            else
            {
                move.x = 0;
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
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

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
                facingRight = true;
            }
            else if (move.x < -0.01f){
                spriteRenderer.flipX = true;
                facingRight = false;
            }

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

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

        public void bulletShootRight(){
            GameObject b = Instantiate(bulletRightPrefab) as GameObject;
            b.transform.position = playerEntity.transform.position;
        }
        public void bulletShootLeft(){
            GameObject b = Instantiate(bulletLeftPrefab) as GameObject;
            b.transform.position = playerEntity.transform.position;
        }
    }
}