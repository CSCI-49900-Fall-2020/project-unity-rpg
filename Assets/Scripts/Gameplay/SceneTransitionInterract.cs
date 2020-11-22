using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionInterract : MonoBehaviour
{
    public string sceneName;
    public Transform player;
    public Vector2 spawnPoint;
    public bool changeCamera;
    public GameObject currCamera;
    private GameObject mainCamera;
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
        mainCamera = GameObject.Find("Main Camera");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.tag == "Player")
        {
            player = other.GetComponent<Collider2D>().gameObject.transform;
            SceneManager.LoadScene(sceneName);
            player.position = spawnPoint;

            if(changeCamera)
            {
                currCamera.SetActive(false);
                mainCamera.SetActive(true);
            }
        }
    }
}
