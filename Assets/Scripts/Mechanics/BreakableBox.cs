using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{

    private ParticleSystem particle;
    private SpriteRenderer sr;
    private PolygonCollider2D bc;
    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<PolygonCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() || collision.gameObject.tag == "bullet")
        {
            Debug.Log("works");
            StartCoroutine(Break());
        }
    }
    private IEnumerator Break()
    {
        particle.Play();
        sr.enabled = false;
        bc.enabled = false;
        if (drops) Instantiate(theDrops, dropPoint.position, dropPoint.rotation);
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);
    }


}
