using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class CharacterSwapping : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public GameObject currentCharacter;
    public CameraFollow mainCamera;
    public HealthBar healthBar;
    public Vector2 tempPosition;

    void Awake(){
        currentCharacter = character1;
        mainCamera.objectToFollow = currentCharacter;
        
        character2.GetComponent<CopyPlayerController>().controlEnabled = false;
        character3.GetComponent<CopyPlayerController>().controlEnabled = false;
        character4.GetComponent<CopyPlayerController>().controlEnabled = false;
    }
    void Start(){
        //healthBar.SetMaxHealth(100, 10);
        healthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
    }

    void Update(){
        if(Input.GetButtonDown("Character1")){
            if(currentCharacter != character1){
                // Disable control of current character
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = false;
                // Swap their positions
                tempPosition = character1.GetComponent<Transform>().position;
                character1.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                // Set new character as currentCharacter and enable control of it
                currentCharacter = character1;
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                healthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
            }
        } else if (Input.GetButtonDown("Character2")){
            if(currentCharacter != character2){
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character2.GetComponent<Transform>().position;
                character2.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character2;
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                healthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
            }
        }else if (Input.GetButtonDown("Character3")){
            if(currentCharacter != character3){
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character3.GetComponent<Transform>().position;
                character3.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character3;
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                healthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
            }
        }else if (Input.GetButtonDown("Character4")){
            if(currentCharacter != character4){
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character4.GetComponent<Transform>().position;
                character4.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character4;
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                healthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
            } 
        }
    }
}
