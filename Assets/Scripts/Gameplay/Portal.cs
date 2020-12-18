using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Platformer.UI;
using Platformer.Mechanics;


public class Portal : MonoBehaviour
{
    public Transform player = null;
    public Vector2 spawnPoint;
    KeyBinds keyBinds;

    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
    }

    bool triggered = false;


    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        player = null;
        Debug.Log(other.gameObject.name+" Exit");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        triggered = true;
        player = other.GetComponent<Collider2D>().gameObject.transform;
        Debug.Log(other.gameObject.name + " Enter");
    }

    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.F))
        {
            if (player.tag == "Player")
            {  
                player.position = spawnPoint;
            }
        }
    }
}
