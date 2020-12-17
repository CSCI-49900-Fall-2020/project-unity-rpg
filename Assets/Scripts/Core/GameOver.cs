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
        
        if(donut != null)
            saveData = donut.GetComponent<SaveData>();
    }

    public void LoadSave(){
        saveData.LoadData();
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
