using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.UI;
using System;

public class CharacterSwapping : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public GameObject currentCharacter;
    public CameraFollow mainCamera;
    public HealthBar mainHealthBar;
    public ManaBar mainManaBar;
    public Text subCharacterName1;
    public HealthBar subHealthBar1;
    public ManaBar subManaBar1;
    public Text subCharacterName2;
    public HealthBar subHealthBar2;
    public ManaBar subManaBar2;
    public Text subCharacterName3;
    public HealthBar subHealthBar3;
    public ManaBar subManaBar3;
    
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
        mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
        mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
        subCharacterName1.text = character2.GetComponent<Character>().characterName;
        subHealthBar1.SetMaxHealth(character2.GetComponent<Health>().maxHP, character2.GetComponent<Health>().currentHP);
        subManaBar1.SetMaxMana(character2.GetComponent<Mana>().maxMP, character2.GetComponent<Mana>().currentMP);
        subCharacterName2.text = character3.GetComponent<Character>().characterName;
        subHealthBar2.SetMaxHealth(character3.GetComponent<Health>().maxHP, character3.GetComponent<Health>().currentHP);
        subManaBar2.SetMaxMana(character3.GetComponent<Mana>().maxMP, character3.GetComponent<Mana>().currentMP);
        subCharacterName3.text = character4.GetComponent<Character>().characterName;
        subHealthBar3.SetMaxHealth(character4.GetComponent<Health>().maxHP, character4.GetComponent<Health>().currentHP);
        subManaBar3.SetMaxMana(character4.GetComponent<Mana>().maxMP, character4.GetComponent<Mana>().currentMP);
    }

    // Helper Function to swap characters
    void subCharacterInfoSwap(int newCharacterID){
        if(currentCharacter == character1){
            // The current state is main = 1, sub = 2,3,4
            if(newCharacterID == 2){
                // Needs to become main = 2, sub = 1,3,4
                subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 3){
                // Needs to become main = 3, sub = 1,2,4
                subCharacterName2.text = subCharacterName1.text;
                subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar1.slider.maxValue), (int)Math.Floor(subHealthBar1.slider.value));
                subManaBar2.SetMaxMana((int)Math.Floor(subManaBar1.slider.maxValue), (int)Math.Floor(subManaBar1.slider.value));
                subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 4) {
                // Needs to become main = 4, sub = 1,2,3
                subCharacterName3.text = subCharacterName2.text;
                subHealthBar3.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                subManaBar3.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                subCharacterName2.text = subCharacterName1.text;
                subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar1.slider.maxValue), (int)Math.Floor(subHealthBar1.slider.value));
                subManaBar2.SetMaxMana((int)Math.Floor(subManaBar1.slider.maxValue), (int)Math.Floor(subManaBar1.slider.value));
                subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        } else if(currentCharacter == character2){
            // The current state is main = 2, sub = 1,3,4
            if(newCharacterID == 1){
                // Needs to become main = 1, sub = 2,3,4
                subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 3){
                // Needs to become main = 3, sub = 1,2,4
                subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 4){
                // Needs to become main = 4, sub = 1,2,3
                subCharacterName3.text = subCharacterName2.text;
                subHealthBar3.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                subManaBar3.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        } else if(currentCharacter == character3){
            // The current state is main = 3, sub = 1,2,4
            if(newCharacterID == 1){
                // Needs to become main = 1, sub = 2,3,4
                subCharacterName1.text = subCharacterName2.text;
                subHealthBar1.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                subManaBar1.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if(newCharacterID == 2){
                // Needs to become main = 2, sub = 1,3,4
                subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 4){
                // Needs to become main = 4, sub = 1,2,3
                subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        } else if(currentCharacter == character4){
            // The current state is main = 4, sub = 1,2,3
            if(newCharacterID == 1){
                // Needs to become main = 1, sub = 2,3,4
                subCharacterName1.text = subCharacterName2.text;
                subHealthBar1.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                subManaBar1.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                subCharacterName1.text = subCharacterName3.text;
                subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar3.slider.maxValue), (int)Math.Floor(subHealthBar3.slider.value));
                subManaBar2.SetMaxMana((int)Math.Floor(subManaBar3.slider.maxValue), (int)Math.Floor(subManaBar3.slider.value));
                subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if(newCharacterID == 2){
                // Needs to become main = 2, sub = 1,3,4
                subCharacterName2.text = subCharacterName3.text;
                subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar3.slider.maxValue), (int)Math.Floor(subHealthBar3.slider.value));
                subManaBar2.SetMaxMana((int)Math.Floor(subManaBar3.slider.maxValue), (int)Math.Floor(subManaBar3.slider.value));
                subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } else if (newCharacterID == 3){
                // Needs to become main = 1, sub = 1,2,4
                subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        }
    } 

    void Update(){
        if(Input.GetButtonDown("Character1")){
            if(currentCharacter != character1){
                subCharacterInfoSwap(1);
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
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        } else if (Input.GetButtonDown("Character2")){
            if(currentCharacter != character2){
                subCharacterInfoSwap(2);
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character2.GetComponent<Transform>().position;
                character2.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character2;
                currentCharacter.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        }else if (Input.GetButtonDown("Character3")){
            if(currentCharacter != character3){
                subCharacterInfoSwap(3);
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character3.GetComponent<Transform>().position;
                character3.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character3;
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        }else if (Input.GetButtonDown("Character4")){
            if(currentCharacter != character4){
                subCharacterInfoSwap(4);
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = false;
                tempPosition = character4.GetComponent<Transform>().position;
                character4.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character4;
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<CopyPlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } 
        }
    }
}
