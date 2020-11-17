using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Platformer.Core;
using Platformer.UI;

public class Recruit : MonoBehaviour
{
    private DialogueOption dialogueOption;
    private DisplayManager displayManager;
    private W84secondsEx wait5s;

    private UnityAction yesEvent, noEvent;

    public bool onbuttonpress;
    private bool waitforpress;
    public bool CloseWhenDone;

    //public string nextSceneName;
    //public string assetsSceneName;

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
    
    //public void TestYN()
    //{
    //    dialogueOption.Choice("Can't seem to do that yet.", yesEvent, noEvent);
    //}

    //public void changeScene(/*string nextSceneName*/)
    //{
    //    SceneManager.LoadScene(assetsSceneName);
    //    //`wait5s.ExampleCoroutine();
    //    SceneManager.LoadScene(nextSceneName);
    //}

    //wrapped into unityactions

    void TestAccept()//recruit member into party
    {
        displayManager.DisplayMessage("Can't seem to do that yet.");
    }

    void TestDecline()
    {
        displayManager.DisplayMessage("Ok whatever.");
        if (CloseWhenDone)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (waitforpress && keyBinds.GetButtonDown("Interract"))
        {
            dialogueOption.Choice("Can I join your party?", yesEvent, noEvent);
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

            dialogueOption.Choice("Can I join your party?", yesEvent, noEvent);
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
