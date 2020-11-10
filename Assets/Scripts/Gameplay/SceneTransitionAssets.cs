using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer.Mechanics;

public class SceneTransitionAssets : MonoBehaviour
{
    public string sceneName;
    public Vector2 spawnPoint = new Vector2(0,0);
    void Start()
    {
        SceneManager.LoadScene(sceneName);
        GetComponent<CharacterSwapping>().currentCharacter.transform.position = spawnPoint;
    }

}
