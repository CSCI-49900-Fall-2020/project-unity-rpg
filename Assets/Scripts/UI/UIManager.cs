using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject playersBars;
    public GameObject BarsBackgroundImage;
    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }
    private void Update()
    {
        InventoryControl();
    }
    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GameManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    private void Resume()
    {
        inventoryMenu.gameObject.SetActive(false);
        playersBars.gameObject.SetActive(true);
        BarsBackgroundImage.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }
    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        playersBars.gameObject.SetActive(false);
        BarsBackgroundImage.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }

}
