using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;

public class UpdateManager : MonoBehaviour
{
    CharacterSwapping characterSwapper;
    KeyBinds keyBinds;
    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        characterSwapper = GetComponent<CharacterSwapping>();
    }

    void Update() {
        if (keyBinds.GetButtonDown("Jump"))
        {
            characterSwapper.currentCharacter.GetComponent<PlayerController>().jump();
        };

        if(Input.GetButtonDown("Character1")){
            characterSwapper.switchToCharacter1();
        }

        if(Input.GetButtonDown("Character2")){
            characterSwapper.switchToCharacter2();
        }

        if(Input.GetButtonDown("Character3")){
            characterSwapper.switchToCharacter3();
        }

        if(Input.GetButtonDown("Character4")){
            characterSwapper.switchToCharacter4();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().controlEnabled){
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerAggro>().toUpdate();
        }

        if (keyBinds.GetButton("Right"))
        {
            characterSwapper.currentCharacter.GetComponent<PlayerController>().moveRight();
        };
        
        if (keyBinds.GetButton("Left"))
        {
            characterSwapper.currentCharacter.GetComponent<PlayerController>().moveLeft();
        };
    }
}
