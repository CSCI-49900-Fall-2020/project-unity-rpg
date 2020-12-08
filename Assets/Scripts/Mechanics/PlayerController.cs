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
        public float moveSpeed = 2;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;
        public float jumpVelocity = 5;
        public int jumpLimit = 1;
        public Collider2D collider2d;
        public Rigidbody2D rb2d;
        public Health health;
        public Mana mana;
        public HealthBar healthBar;
        public ManaBar manaBar;
        public Transform attackPosition;
        public bool controlEnabled = true;
        public bool facingRight = true;
        public List<EquipmentItem> playerCurrentEitems = new List<EquipmentItem>();

        SpriteRenderer spriteRenderer;
        //internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        GameObject donut;

        public bool onGround;
        int jumpCount = 0;

        void Awake()
        {
            health = GetComponent<Health>();
            mana = GetComponent<Mana>();
            //audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            rb2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            //animator = GetComponent<Animator>();
            donut = GameObject.Find("Donut");
        }

        void Start() {
            attackPosition.localPosition = new Vector3(0.25f,0,0);
        }

        protected void Update()
        {
            if( rb2d.velocity.y < 0){
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
            }
        }    

        void Flip()
        {
            facingRight = !facingRight;
            
            int multiply = 1;
            if(!facingRight)
                multiply = -1;

            attackPosition.localPosition = new Vector3(0.25f * multiply,0,0);
            Vector3 flip = attackPosition.localScale;
            flip.x *= -1;
            attackPosition.localScale = flip;
        }
        public void InsertEquipmentItemToPlayer(EquipmentItem eitem)
        {
            if (playerCurrentEitems.Count == 0)
            {
                playerCurrentEitems.Add(eitem);
                setMaxHealth(health.maxHP + eitem.value);
                return;
                //playerCurrentHealth = health.maxHP + eitem.value;
            }
            else
            {
                if (eitem.EquipmentID == 5)
                {
                    ////
                    return;
                }
                else
                {
                    //check if the player has already one of those elements
                    for (int i = 0; i < playerCurrentEitems.Count; i++)
                    {
                        if (playerCurrentEitems[i].EquipmentID == eitem.EquipmentID)
                        {
                            setMaxHealth(health.maxHP - playerCurrentEitems[i].value);
                            playerCurrentEitems.Remove(playerCurrentEitems[i]);
                            playerCurrentEitems.Add(eitem);
                            setMaxHealth(health.maxHP + eitem.value);
                            return;
                        }
                    }
                    //add element
                    playerCurrentEitems.Add(eitem);
                    setMaxHealth(health.maxHP + eitem.value);
                    return;
                }
            }
        }


        public void moveRight()
        {
            if(controlEnabled)
                transform.position += transform.right * (Time.deltaTime * moveSpeed);
            if(!facingRight)
                Flip();
        }

        public void moveLeft()
        {
            if(controlEnabled)
                transform.position -= transform.right * (Time.deltaTime * moveSpeed);
            if(facingRight)
                Flip();
        }

        public void highJump(){
            if (rb2d.velocity.y == 0) {
                rb2d.velocity = Vector2.up * jumpVelocity;
            }
        }

        public void lowJump(){
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        public void jump(){
            if(jumpCount < jumpLimit){
                jumpCount++;
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

        public  void setMaxMana(int value){
            mana.Decrement(value);
            manaBar.SetMaxMana(mana.maxMP, mana.currentMP);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.CompareTag("Ground"))
            {
                onGround = true;
                jumpCount = 0;
            }
        }
    }
}