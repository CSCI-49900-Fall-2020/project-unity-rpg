﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Platformer.Core;
using Platformer.UI;

public class TestDialogueOption : MonoBehaviour
{
    private DialogueOption dialogueOption;
    private DisplayManager displayManager;
    private W84secondsEx wait5s;

    private UnityAction yesEvent, noEvent;

    public bool onbuttonpress;
    private bool waitforpress;
    public bool CloseWhenDone;

    public string nextSceneName;
    public string assetsSceneName;

    KeyBinds keyBinds;

    void Awake()
    {
        dialogueOption = DialogueOption.Instance();
        displayManager = DisplayManager.Instance();
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();

        yesEvent = new UnityAction(TestAccept);
        noEvent = new UnityAction(TestDecline);
    }

    //set up buttons and functions
    
    public void TestYN()
    {
        dialogueOption.Choice("Ohoho, you're approaching me?", yesEvent, noEvent);
    }

    public void changeScene(/*string nextSceneName*/)
    {
        SceneManager.LoadScene(assetsSceneName);
        //`wait5s.ExampleCoroutine();
        SceneManager.LoadScene(nextSceneName);
    }

    //wrapped into unityactions

    void TestAccept()
    {
        displayManager.DisplayMessage("I can't beat the sh*t out of you without getting closer");
    }

    void TestDecline()
    {
        displayManager.DisplayMessage("Nah bro");
        if (CloseWhenDone)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (waitforpress && keyBinds.GetButtonDown("Interract"))
        {
            dialogueOption.Choice("Ohoho, you're approaching me?", yesEvent, noEvent);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (onbuttonpress)
            {
                waitforpress = true;
                return;
            }

            dialogueOption.Choice("Ohoho, you're approaching me?", yesEvent, noEvent);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            waitforpress = false;
        }
    }

}
