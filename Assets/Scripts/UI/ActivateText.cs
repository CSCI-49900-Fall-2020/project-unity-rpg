using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.UI;
using Platformer.Mechanics;

public class ActivateText : MonoBehaviour
{
    public TextAsset theText;

    public int start;
    public int end;

    public GameObject textboxGameObject;
    public TextBoxManager textbox;

    public bool onbuttonpress;
    private bool waitforpress;

    public bool stopPlayerMovement; //reserve for one line dialogue
    public CharacterSwapping characterSwapper; //used to stop character

    public new bool DestroyObject;
    KeyBinds keyBinds;

    //public string[] lines;
    //public Text line;

    // Start is called before the first frame update
    void Start()
    {
        //textboxGameObject = GameObject.FindGameObjectWithTag("TextBox");
        //textbox = textboxGameObject.GetComponent<TextBoxManager>();
        textbox = FindObjectOfType<TextBoxManager>();
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        characterSwapper = FindObjectOfType<CharacterSwapping>();
        //line = GameObject.FindGameObjectWithTag("TextBoxText").GetComponent<Text>();

        //if (end == 0) //if endline is unspecified, go to the end
        //{
        //    end = lines.Length - 1;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (waitforpress && keyBinds.GetButtonDown("Interract"))
        {
            if (theText != null)
            {
                textbox.reuse(theText);
            }
            //else if (start < lines.Length)
            //{
            //    line.text = lines[start];
            //}
            textbox.currentline = start;
            textbox.endatline = end;
            textbox.enable();
            
            if (stopPlayerMovement)
            {
                characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
            }
            
            if (DestroyObject)
            {
                Destroy(gameObject);
            }
            waitforpress = false;
        }
        //else if (lines.Length != 0)
        //{
        //    //activate Textbox
        //    //each line in lines = each line in TextBox
        //    //advance by getting interact
        //}
    }

    //activate when player enters collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (onbuttonpress)
            {
                waitforpress = true;
                return;
            }
            textbox.reuse(theText);
            textbox.currentline = start;
            textbox.endatline = end;
            textbox.enable();
            
            if (stopPlayerMovement)
            {
                characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
            }
            
            if (DestroyObject)
            {
                Destroy(gameObject);
            }
        }
    }

    //activate when player leaves collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(textbox != null)
                textbox.disable();
            waitforpress = false;
        }
    }

}
