using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textbox;

    public Text theText;

    public TextAsset textfile;
    public string[] textlines;

    public int currentline;
    public int endatline;

    public PlayerController player;

    public bool isActive;


    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        if (endatline == 0) //if endline is unspecified, go to the end
        {
            endatline = textlines.Length - 1;
        }

        if (isActive)
        {
            enable();
        }
        else
        {
            disable();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
        {
            return;
        }

        theText.text = textlines[currentline];

        if (Input.GetKeyDown(KeyCode.Return)) // press return/enter advances text
        {
            currentline += 1;
        }

        if (currentline > endatline) // once you reach the end, box disappears
        {
            disable();
        }
    }

    public void enable() //add textbox
    {
        textbox.SetActive(true);
        isActive = true;

    }

    public void disable() //take away textbox
    {
        textbox.SetActive(false);
        isActive = false;

    }

    public void reuse(TextAsset theText) //reuse textbox
    {
        if (theText != null)
        {
            textlines = new string[1];
            textlines = (theText.text.Split('\n'));
        }
    }

}