using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateText : MonoBehaviour
{
    public TextAsset theText;

    public int start;
    public int end;

    public GameObject textboxGameObject;
    public TextBoxManager textbox;

    public bool onbuttonpress;
    private bool waitforpress;

    public bool CloseWhenDone;
    KeyBinds keyBinds;

    // Start is called before the first frame update
    void Start()
    {
        //textboxGameObject = GameObject.FindGameObjectWithTag("TextBox");
        //textbox = textboxGameObject.GetComponent<TextBoxManager>();
        textbox = FindObjectOfType<TextBoxManager>();
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
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

            if (CloseWhenDone)
            {
                Destroy(gameObject);
            }
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

            if (CloseWhenDone)
            {
                Destroy(gameObject);
            }
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
