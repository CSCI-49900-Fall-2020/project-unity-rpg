using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Platformer.Mechanics;
using Platformer.UI;

public class DialogueOption : MonoBehaviour
{
    public Text question;
    //public Text message;
    //public Text accept, decline;
    public Button acceptButton, declineButton;
    public GameObject window;
    public PlayerController player;
    KeyBinds keyBinds;
    public bool stopPlayerMovement;
    public GameObject Donut;
    public string scriptName1;
    public TextBoxManager textBoxManager;

    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<PlayerController>();
        //question = GameObject.Find("Question").GetComponent<Text>();
        //acceptButton = GameObject.Find("Yes Button").GetComponent<Button>();
        //declineButton = GameObject.Find("No Button").GetComponent<Button>();
        //window = GameObject.FindGameObjectWithTag("DialogueText");
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        textBoxManager = gameObject.GetComponent<TextBoxManager>();
    }
    void Update()
    {
        //player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private static DialogueOption instance;
    public static DialogueOption Instance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(DialogueOption)) as DialogueOption;
            //if (!instance)
            //    Debug.Log("There need to be at least one active DialogueOption script on a GameObject in your scene.");
            //return;
        }

        return instance;
    }
    
    public void Choice(string question, UnityAction accept, UnityAction decline)
    {
        if (stopPlayerMovement)
        {
            //player.controlEnabled = false;
            if(textBoxManager.characterSwapper.currentCharacter != null)
            {
                textBoxManager.characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
                //player.controlEnabled = false;
            }
        }

        window.SetActive(true);
        (Donut.GetComponent(scriptName1) as MonoBehaviour).enabled = false;

        if (acceptButton != null || declineButton != null)
        {
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
    }

    void CloseWindow()
    {
        if (stopPlayerMovement)
        {
            if(textBoxManager.characterSwapper.currentCharacter != null)
            {
                textBoxManager.characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = true;
            }
            // if (player != null)
            // {
            //     player.controlEnabled = true;
            // }
        }
        //player.controlEnabled = true;
        window.SetActive(false);
        (Donut.GetComponent(scriptName1) as MonoBehaviour).enabled = true;
    }
}
