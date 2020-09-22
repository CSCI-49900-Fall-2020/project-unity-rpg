using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isPaused = false;
    public enum PauseMethod
    {
        CharacterSwap,
        GamePause
    }

    public PauseMethod pauseMethod;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            pauseMethod = PauseMethod.CharacterSwap;

            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMethod = PauseMethod.GamePause;

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
