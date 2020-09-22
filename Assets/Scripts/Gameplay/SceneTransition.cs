using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scene_name;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(scene_name);
    }
}
