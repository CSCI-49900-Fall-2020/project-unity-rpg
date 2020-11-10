using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;

public class UpdateManager : MonoBehaviour
{
    KeyBinds keyBinds;
    // Start is called before the first frame update
    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
    }

    void Update() {
        if(Input.GetKeyDown("n")){
            Debug.Log("Hurting current character");
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().decrementHealth(5);
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

        if(gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().jumpState == JumpState.Grounded && keyBinds.GetButtonDown("Jump")){
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().startJump();
        } else (keyBinds.GetButtonDown("Jump")){
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().stopJump();
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
