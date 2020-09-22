using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestDialogueOption : MonoBehaviour
{
    private DialogueOption dialogueOption;
    private DisplayManager displayManager;

    private UnityAction yesEvent, noEvent;

    void Awake()
    {
        dialogueOption = DialogueOption.Instance();
        displayManager = DisplayManager.Instance();

        yesEvent = new UnityAction(TestAccept);
        noEvent = new UnityAction(TestDecline);
    }

    //set up buttons and functions

    public void TestYN()
    {
        dialogueOption.Choice("Yes or No", yesEvent, noEvent);
    }

    //wrapped into unityactions

    void TestAccept()
    {
        displayManager.DisplayMessage("Yes Accepted");
    }

    void TestDecline()
    {
        displayManager.DisplayMessage("No Declined");
    }

}
