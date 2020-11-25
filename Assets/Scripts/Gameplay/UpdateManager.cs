using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;

public class UpdateManager : MonoBehaviour
{
    CharacterSwapping characterSwapper;
    KeyBinds keyBinds;
    // Start is called before the first frame update
    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
        characterSwapper = GetComponent<CharacterSwapping>();
    }

    void Update() {
        if(Input.GetKeyDown("n")){
            // Debug.Log("Hurting current character");
            // characterSwapper.currentCharacter.GetComponent<PlayerController>().decrementHealth(5);
            Debug.Log("testing");
            //characterSwapper.currentCharacter.GetComponent<PlayerController>().Bounce(new Vector2(5, 5));
            characterSwapper.currentCharacter.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5), ForceMode2D.Impulse);
        }    

        // if(characterSwapper.currentCharacter.GetComponent<Rigidbody2D>().velocity.y > 0 && !keyBinds.GetButton("Jump")) {
            
        //     Debug.Log("characterSwapper.currentCharacter.name");
        //     characterSwapper.currentCharacter.GetComponent<PlayerController>().lowJump();
        // }

        if (keyBinds.GetButtonDown("Jump"))
        {
            Debug.Log("A");
            //characterSwapper.currentCharacter.GetComponent<PlayerController>().highJump();
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
        
        if (keyBinds.GetButtonUp("Right") || keyBinds.GetButtonUp("Left"))
        {
            characterSwapper.currentCharacter.GetComponent<PlayerController>().stop();
        };

        // if(Input.GetKeyDown("m")){
        //     Debug.Log(Time.deltaTime + "Before update");
        //     playerAggro.check();
        //     playerAggro.toUpdate();
        //     Debug.Log(Time.deltaTime + "After update");
        //     playerAggro.check();
        // }
    }
}
