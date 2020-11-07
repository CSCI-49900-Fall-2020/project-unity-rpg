using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public bool DestroyObject;
    KeyBinds keyBinds;

    // Start is called before the first frame update
    void Start()
    {
        //textboxGameObject = GameObject.FindGameObjectWithTag("TextBox");
        //textbox = textboxGameObject.GetComponent<TextBoxManager>();
        textbox = FindObjectOfType<TextBoxManager>();
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        characterSwapper = FindObjectOfType<CharacterSwapping>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitforpress && keyBinds.GetButtonDown("Interract"))
        {
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
            waitforpress = false;
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            textbox.disable();
            waitforpress = false;
        }
    }

}
