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

        if (keyBinds.GetButton("Right"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().moveRight();
        };
        
        if (keyBinds.GetButton("Left"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().moveLeft();
        };
        
        if (keyBinds.GetButtonUp("Right") || keyBinds.GetButtonUp("Left"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().stop();
        };

        if (Input.GetButton("Jump"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().highJump();
        };

        if(characterSwapper.currentCharacter.GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetButton("Jump")) {
            characterSwapper.currentCharacter.GetComponent<PlayerController>().lowJump();
        }

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

        // if(Input.GetKeyDown("m")){
        //     Debug.Log(Time.deltaTime + "Before update");
        //     playerAggro.check();
        //     playerAggro.toUpdate();
        //     Debug.Log(Time.deltaTime + "After update");
        //     playerAggro.check();
        // }
    }
}
