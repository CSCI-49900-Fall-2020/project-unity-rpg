using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject donut;
    SaveData saveData;
    DoNotDestroyOnTransition[] toDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        toDestroy = GameObject.FindObjectsOfType<DoNotDestroyOnTransition>();

        donut = GameObject.Find("Donut");
        saveData = donut.GetComponent<SaveData>();
    }
    
    public void LoadSave(){
        donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Rigidbody2D>().gravityScale = 0;
        saveData.LoadData();
        donut.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void GoToTitle(){
        GameObject temp;

        foreach(DoNotDestroyOnTransition obj in toDestroy){
            temp = obj.gameObject;
            Destroy(temp);
        }

        SceneManager.LoadScene("Title");
    }
}
