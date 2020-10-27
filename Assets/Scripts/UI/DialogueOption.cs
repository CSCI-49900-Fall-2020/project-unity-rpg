using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Platformer.Mechanics;

public class DialogueOption : MonoBehaviour
{
    public Text question;
    //public Text message;
    //public Text accept, decline;
    public Button acceptButton, declineButton;
    public GameObject window;
    public PlayerController player;

    public bool stopPlayerMovement;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        //question = GameObject.Find("Question").GetComponent<Text>();
        //acceptButton = GameObject.Find("Yes Button").GetComponent<Button>();
        //declineButton = GameObject.Find("No Button").GetComponent<Button>();
        //window = GameObject.FindGameObjectWithTag("DialogueText");

    }
    
    private static DialogueOption instance;
    public static DialogueOption Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(DialogueOption)) as DialogueOption;
            if (!instance)
                Debug.Log("There need to be at least one active DialogueOption script on a GameObject in your scene.");
            //return;
        }

        return instance;
    }
    
    public void Choice(string question, UnityAction accept, UnityAction decline)
    {
        if (stopPlayerMovement)
        {
            //player.controlEnabled = false;
            if(player != null)
            {
                player.controlEnabled = false;
            }
        }

        window.SetActive(true);

        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(accept);
        acceptButton.onClick.AddListener(CloseWindow);

        declineButton.onClick.RemoveAllListeners();
        declineButton.onClick.AddListener(decline);
        declineButton.onClick.AddListener(CloseWindow);

        this.question.text = question;

        acceptButton.gameObject.SetActive(true);
        declineButton.gameObject.SetActive(true);
    }

    void CloseWindow()
    {
        if (stopPlayerMovement)
        {
            if (player != null)
            {
                player.controlEnabled = true;
            }
        }
        //player.controlEnabled = true;
        window.SetActive(false);
    }
}
