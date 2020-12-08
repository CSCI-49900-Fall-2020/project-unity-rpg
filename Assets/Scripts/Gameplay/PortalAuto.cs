using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Platformer.UI;
using Platformer.Mechanics;


public class PortalAuto : MonoBehaviour
{
    //public string sceneName;
    public Transform player;
    public Vector2 spawnPoint;
    public bool isBossDoor;
    public bool isBossDoorEntrance;
    public bool isBossDoorExit;
    public GameObject bossCamera;
    public GameObject mainCamera;
    public Health bossHealth;
    public string sceneName;
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        player = other.GetComponent<Collider2D>().gameObject.transform;
    //        player.position = spawnPoint;

    //    }
    //}

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        player = other.GetComponent<Collider2D>().gameObject.transform;
        //SceneManager.LoadScene(sceneName);
        player.position = spawnPoint;
        //bossHealth = GameObject.Find("sword_boss").GetComponent<Health>();
        GameObject temp = GameObject.Find("sword_boss");
        if(temp != null)
        {
            bossHealth = GameObject.Find("sword_boss").GetComponent<Health>();
        }
        if (isBossDoor)
        {
            if (isBossDoorEntrance)
            {
                bossCamera.SetActive(true);
                mainCamera.SetActive(false);
                player.position = spawnPoint;
            }
            else if(isBossDoorExit)
            {
                if (bossHealth == null || bossHealth.currentHP == 0)
                {
                    bossCamera.SetActive(false);
                    mainCamera.SetActive(true);
                    player.position = spawnPoint;
                    SceneManager.LoadScene(sceneName);
                }
            }
            //else if (bossHealth.currentHP == 0)
            //{
            //    bossCamera.SetActive(false);
            //    mainCamera.SetActive(true);
            //    player.position = spawnPoint;
            //}
            else
            {
                player.position = spawnPoint;
            }
        }
        //if (isBossDoor)
        //{
        //    if (isBossDoorEntrance)
        //    {
        //        bossCamera.SetActive(True);
        //        mainCamera.SetActive(False);
        //        player.position = spawnPoint;
        //    }
        //    else if (bossHealth.currentHP == 0)
        //    {
        //        bossCamera.SetActive(False);
        //        mainCamera.SetActive(True);
        //        player.position = spawnPoint;
        //    }
        //}
        //else
        //{
        //    player.position = spawnPoint;
        //}
    }
}
