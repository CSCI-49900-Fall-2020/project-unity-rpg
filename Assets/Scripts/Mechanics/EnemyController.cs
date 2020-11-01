using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public GameObject healthBarPrefab;
        public GameObject healthBar;
        //public HealthBar healthBar;
        public Health health;

        public Bounds Bounds => _collider.bounds;

        public float knockbackPower = 100;
        public float knockbackDuration = 1;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            health = GetComponent<Health>();
        }

        void Start() {
            healthBar = Instantiate(healthBarPrefab, new Vector3(0,0,0), Quaternion.identity);
            healthBar.transform.SetParent(gameObject.transform);
            healthBar.transform.localPosition = new Vector3(0,0.25f,0);
            healthBar.transform.GetChild(0).GetComponent<EnemyHPBar>().SetMaxHealth(health.maxHP, health.currentHP);
            
        }

        // Old OnCollisionEnter2D
        // void OnCollisionEnter2D(Collision2D collision)
        // {
        //     var player = collision.gameObject.GetComponent<PlayerController>();
            
        //     if (player != null)
        //     {
        //         var ev = Schedule<PlayerEnemyCollision>();
        //         ev.player = player;
        //         ev.enemy = this;
        //     }
        // }

        public void HealthDecrement(int damage){
            health.Decrement(damage);
            healthBar.transform.GetChild(0).GetComponent<EnemyHPBar>().SetCurrentHealth(health.currentHP);
            
            if(health.currentHP == 0){
                Destroy(gameObject);
            }
        }

        void Update()
        {
            if (path != null)
            {
                if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }
        }

    }
}