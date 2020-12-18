using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;
using Platformer.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textbox;

    public Text theText;

    public TextAsset textfile;
    public string[] textlines;

    public int currentline;
    public int endatline;

    public bool isActive; //activate immediately upon entering scene, used for testing purposes

    public bool stopPlayerMovement;

    public GameObject Donut; //Hold all the scripts to be disabled, The brain of the game
    public string scriptName1; //Disable during textbox active

    KeyBinds keyBinds;

    public CharacterSwapping characterSwapper;

    void Start()
    {
        textbox = GameObject.FindGameObjectWithTag("TextBox");
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();

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

        if(currentline < textlines.Length)
            theText.text = textlines[currentline];

        if (keyBinds.GetButtonDown("Interract")) // press return/enter advances text
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

        (Donut.GetComponent(scriptName1) as MonoBehaviour).enabled = false;

        isActive = true;
        if (stopPlayerMovement)
        {   
            characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
        }
    }

    public void disable() //take away textbox
    {
        textbox.SetActive(false);
        (Donut.GetComponent(scriptName1) as MonoBehaviour).enabled = true;

        isActive = false;
        characterSwapper.currentCharacter.GetComponent<PlayerController>().controlEnabled = true;
    }

    //Reuse textbox and use dialogue from a seperate script
    public void reuse(TextAsset theText)
    {
        if (theText != null)
        {
            textlines = new string[1];
            textlines = (theText.text.Split('\n'));
        }
    }

}