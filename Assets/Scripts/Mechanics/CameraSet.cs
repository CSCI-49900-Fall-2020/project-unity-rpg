using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bossCamera;
    public GameObject boss;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter2D()
    {
        mainCamera.SetActive(false);
        bossCamera.SetActive(true);
    }

    void OnTriggerExit2D()
    {
        mainCamera.SetActive(true);
        bossCamera.SetActive(false);
    }
}
