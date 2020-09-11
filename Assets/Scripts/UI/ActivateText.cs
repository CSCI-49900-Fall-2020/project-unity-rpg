﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateText : MonoBehaviour
{
    public TextAsset theText;

    public int start;
    public int end;

    public TextBoxManager textbox;

    public bool onbuttonpress;
    private bool waitforpress;

    public bool CloseWhenDone;

    // Start is called before the first frame update
    void Start()
    {
        textbox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitforpress && Input.GetKeyDown(KeyCode.Y))
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
        if(other.name == "Player")
        {
            if(onbuttonpress)
            {
                waitforpress = true;
                return;
            }
            textbox.reuse(theText);
            textbox.currentline = start;
            textbox.endatline = end;
            textbox.enable();

            if(CloseWhenDone)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            waitforpress = false;
        }
    }

}
