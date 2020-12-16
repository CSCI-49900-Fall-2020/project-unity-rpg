using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Platformer.UI;
using Platformer.Mechanics;


public class Portal : MonoBehaviour
{
    //public string sceneName;
    public Transform player = null;
    public Vector2 spawnPoint;
    KeyBinds keyBinds;
    //Read Note Below--------------------------------------------------------------------
    // bool triggered = false;
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     triggered = true;
    //     player = other.GetComponent<Collider2D>().gameObject.transform;
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     triggered = false;
    //     player = null;
    // }

    // void Update()
    // {
    //     if (triggered && Input.GetKeyDown(KeyCode.F))
    //     {
    //         if(player.tag == "Player"){
    //             SceneManager.LoadScene(sceneName);
    //             player.position = spawnPoint;
    //         }
    //     }
    // }

    //The above can potentially cause lag because it is constantly checking the if condition
    //Try to get the below to work

    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
    }

    /*  private void OnTriggerStay2D(Collider2D other)
      {
          //keyBinds.GetButtonDown("Up") //Input.GetKeyDown(KeyCode.F) original
          if (keyBinds.GetButtonDown("Up") && other.tag == "Player")
          {
              player = other.GetComponent<Collider2D>().gameObject.transform;
              //SceneManager.LoadScene(sceneName);
              player.position = spawnPoint;
          }
      }*/
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
                //SceneManager.LoadScene(sceneName);
                player.position = spawnPoint;
            }
        }
    }



}
