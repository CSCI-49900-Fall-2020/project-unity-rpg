using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAuto : MonoBehaviour
{
    public string sceneName;
    public Transform player;
    public Vector2 spawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Collider2D>().gameObject.transform;
        SceneManager.LoadScene(sceneName);
        player.position = spawnPoint;
    }
}
