using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public DoNotDestroyOnTransition[] toDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        toDestroy = GameObject.FindObjectsOfType<DoNotDestroyOnTransition>();

        foreach(DoNotDestroyOnTransition obj in toDestroy){
            temp = obj.gameObject;
            Destroy(temp);
        }
    }

    void Update() {
        if(Input.anyKey){
            SceneManager.LoadScene("Title");
        }
    }
}
