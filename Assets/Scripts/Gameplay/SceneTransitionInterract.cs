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
    bool triggered = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        triggered = true;
        player = other.GetComponent<Collider2D>().gameObject.transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
        player = null;
    }

    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.F))
        {
            if(player.tag == "Player"){
                if(changeCamera)
                    currCamera.SetActive(false);

                SceneManager.LoadScene(sceneName);
                player.position = spawnPoint;

                if(changeCamera)
                    mainCamera.SetActive(true);
            }
        }
    }

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }
}
