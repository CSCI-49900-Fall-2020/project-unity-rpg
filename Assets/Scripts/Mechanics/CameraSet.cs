using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject bossCamera;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
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

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.attachedRigidbody)
    //        other.attachedRigidbody.AddForce(Vector3.up * 10);
    //}    //void OnTriggerStay2D(Collider2D other)

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.SetActive(true);
            bossCamera.SetActive(false);
        }
    }
}
