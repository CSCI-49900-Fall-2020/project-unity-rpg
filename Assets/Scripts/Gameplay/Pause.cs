using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isPaused = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

}
