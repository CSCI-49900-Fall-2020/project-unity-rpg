using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class CameraSet : MonoBehaviour
{
    GameObject donut;
    public GameObject mainCamera;
    public GameObject bossCamera;

    void Start()
    {
        donut = GameObject.Find("Donut");
        if(donut != null)
            mainCamera = donut.GetComponent<CharacterSwapping>().mainCamera.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    //void OnCollisionEnter2D()
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.SetActive(false);
            bossCamera.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.SetActive(true);
            bossCamera.SetActive(false);
        }
    }
}
