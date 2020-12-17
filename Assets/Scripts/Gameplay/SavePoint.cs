using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{
    GameObject donut;
    
    SaveData saveData;
    CharacterSwapping characterSwapper;
    GameObject AliceGO;
    GameObject BobGO;
    GameObject CharlieGO;
    GameObject DaveGO;

    public bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        donut = GameObject.Find("Donut");
        saveData = donut.GetComponent<SaveData>();
        characterSwapper = donut.GetComponent<CharacterSwapping>();

        AliceGO = characterSwapper.character1;
        BobGO = characterSwapper.character2;
        CharlieGO = characterSwapper.character3;
        DaveGO = characterSwapper.character4;
    }

    public void save(){
        Debug.Log("Data Saved");
        saveData.save(
            transform.position,
            SceneManager.GetActiveScene().name,
            characterSwapper.currentCharacter.GetComponent<PlayerController>().characterID
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        triggered = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        triggered = false;
    }

    void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.F))
        {
            save();
        }
    }
}
