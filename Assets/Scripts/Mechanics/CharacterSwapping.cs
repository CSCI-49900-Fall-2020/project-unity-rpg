using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.UI;
using System;
using Platformer.UI;

namespace Platformer.Mechanics
{
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
        Vector2 tempPosition;
        HealthBar tempHealthBar;
        ManaBar tempManaBar;
        // public TextBoxManager textBoxManager;
        // public DialogueOption dialogueOption;

        void Awake(){
            currentCharacter = character1;
            mainCamera.objectToFollow = currentCharacter;
            // textBoxManager.player = currentCharacter.GetComponent<PlayerController>();
            // dialogueOption.player = currentCharacter.GetComponent<PlayerController>();
        }
        void Start(){
            character2.GetComponent<PlayerController>().controlEnabled = false;
            character3.GetComponent<PlayerController>().controlEnabled = false;
            character4.GetComponent<PlayerController>().controlEnabled = false;
            
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

            currentCharacter.GetComponent<PlayerController>().healthBar = mainHealthBar;
            currentCharacter.GetComponent<PlayerController>().manaBar = mainManaBar;
            character2.GetComponent<PlayerController>().healthBar = subHealthBar1;
            character2.GetComponent<PlayerController>().manaBar = subManaBar1;
            character3.GetComponent<PlayerController>().healthBar = subHealthBar2;
            character3.GetComponent<PlayerController>().manaBar = subManaBar2;
            character4.GetComponent<PlayerController>().healthBar = subHealthBar3;
            character4.GetComponent<PlayerController>().manaBar = subManaBar3;
        }

        // Helper Function to swap characters
        void subCharacterInfoSwap(int newCharacterID){
            tempHealthBar = currentCharacter.GetComponent<PlayerController>().healthBar;
            tempManaBar = currentCharacter.GetComponent<PlayerController>().manaBar;

            if(currentCharacter == character1){
                // The current state is main = 1, sub = 2,3,4
                if(newCharacterID == 2){
                    // Needs to become main = 2, sub = 1,3,4
                    subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character1.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character1.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character2.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if (newCharacterID == 3){
                    // Needs to become main = 3, sub = 1,2,4
                    subCharacterName2.text = subCharacterName1.text;
                    subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar1.slider.maxValue), (int)Math.Floor(subHealthBar1.slider.value));
                    subManaBar2.SetMaxMana((int)Math.Floor(subManaBar1.slider.maxValue), (int)Math.Floor(subManaBar1.slider.value));
                    subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character1.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character1.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character3.GetComponent<PlayerController>().manaBar = tempManaBar;
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
                    character1.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character1.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = character4.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character4.GetComponent<PlayerController>().manaBar;
                    character4.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character4.GetComponent<PlayerController>().manaBar = tempManaBar;
                }
            } else if(currentCharacter == character2){
                // The current state is main = 2, sub = 1,3,4
                if(newCharacterID == 1){
                    // Needs to become main = 1, sub = 2,3,4
                    subCharacterName1.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar1.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar1.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character2.GetComponent<PlayerController>().healthBar = character1.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character1.GetComponent<PlayerController>().manaBar;
                    character1.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character1.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if (newCharacterID == 3){
                    // Needs to become main = 3, sub = 1,2,4
                    subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character2.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character3.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if (newCharacterID == 4){
                    // Needs to become main = 4, sub = 1,2,3
                    subCharacterName3.text = subCharacterName2.text;
                    subHealthBar3.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                    subManaBar3.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                    subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character2.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = character4.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character4.GetComponent<PlayerController>().manaBar;
                    character4.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character4.GetComponent<PlayerController>().manaBar = tempManaBar;
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
                    character3.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = character1.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character1.GetComponent<PlayerController>().manaBar;
                    character1.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character1.GetComponent<PlayerController>().manaBar = tempManaBar;

                } else if(newCharacterID == 2){
                    // Needs to become main = 2, sub = 1,3,4
                    subCharacterName2.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar2.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar2.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character3.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character2.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if (newCharacterID == 4){
                    // Needs to become main = 4, sub = 1,2,3
                    subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character3.GetComponent<PlayerController>().healthBar = character4.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character4.GetComponent<PlayerController>().manaBar;
                    character4.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character4.GetComponent<PlayerController>().manaBar = tempManaBar;
                }
            } else if(currentCharacter == character4){
                // The current state is main = 4, sub = 1,2,3
                if(newCharacterID == 1){
                    // Needs to become main = 1, sub = 2,3,4
                    subCharacterName1.text = subCharacterName2.text;
                    subHealthBar1.SetMaxHealth((int)Math.Floor(subHealthBar2.slider.maxValue), (int)Math.Floor(subHealthBar2.slider.value));
                    subManaBar1.SetMaxMana((int)Math.Floor(subManaBar2.slider.maxValue), (int)Math.Floor(subManaBar2.slider.value));
                    subCharacterName2.text = subCharacterName3.text;
                    subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar3.slider.maxValue), (int)Math.Floor(subHealthBar3.slider.value));
                    subManaBar2.SetMaxMana((int)Math.Floor(subManaBar3.slider.maxValue), (int)Math.Floor(subManaBar3.slider.value));
                    subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character4.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character4.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = character1.GetComponent<PlayerController>().healthBar;
                    character2.GetComponent<PlayerController>().manaBar = character1.GetComponent<PlayerController>().manaBar;
                    character1.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character1.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if(newCharacterID == 2){
                    // Needs to become main = 2, sub = 1,3,4
                    subCharacterName2.text = subCharacterName3.text;
                    subHealthBar2.SetMaxHealth((int)Math.Floor(subHealthBar3.slider.maxValue), (int)Math.Floor(subHealthBar3.slider.value));
                    subManaBar2.SetMaxMana((int)Math.Floor(subManaBar3.slider.maxValue), (int)Math.Floor(subManaBar3.slider.value));
                    subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character4.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character4.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = character2.GetComponent<PlayerController>().healthBar;
                    character3.GetComponent<PlayerController>().manaBar = character2.GetComponent<PlayerController>().manaBar;
                    character2.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character2.GetComponent<PlayerController>().manaBar = tempManaBar;
                } else if (newCharacterID == 3){
                    // Needs to become main = 1, sub = 1,2,4
                    subCharacterName3.text = currentCharacter.GetComponent<Character>().characterName;
                    subHealthBar3.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    subManaBar3.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                    character4.GetComponent<PlayerController>().healthBar = character3.GetComponent<PlayerController>().healthBar;
                    character4.GetComponent<PlayerController>().manaBar = character3.GetComponent<PlayerController>().manaBar;
                    character3.GetComponent<PlayerController>().healthBar = tempHealthBar;
                    character3.GetComponent<PlayerController>().manaBar = tempManaBar;
                }
            }
        } 
        
        public void switchToCharacter1(){
            if(currentCharacter.GetComponent<PlayerController>().controlEnabled){
                if(currentCharacter != character1 && character1.GetComponent<PlayerController>().health.currentHP != 0){
                    subCharacterInfoSwap(1);
                    // Disable control of current character
                    currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
                    // Swap their positions
                    tempPosition = character1.GetComponent<Transform>().position;
                    character1.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                    currentCharacter.GetComponent<Transform>().position = tempPosition;
                    // Set new character as currentCharacter and enable control of it
                    currentCharacter = character1;
                    // textBoxManager.player = currentCharacter.GetComponent<PlayerController>();
                    // dialogueOption.player = currentCharacter.GetComponent<PlayerController>();
                    currentCharacter.GetComponent<PlayerController>().controlEnabled = true;
                    mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                    mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                    mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
                }
            }
        }
        public void switchToCharacter2(){
            if(currentCharacter != character2 && character2.GetComponent<PlayerController>().health.currentHP != 0){
                subCharacterInfoSwap(2);
                currentCharacter.GetComponent<PlayerController>().controlEnabled = false;
                tempPosition = character2.GetComponent<Transform>().position;
                character2.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character2;
                // textBoxManager.player = currentCharacter.GetComponent<PlayerController>();
                // dialogueOption.player = currentCharacter.GetComponent<PlayerController>();
                currentCharacter.GetComponent<PlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }
        }

        public void switchToCharacter3(){
            if(currentCharacter != character3  && character3.GetComponent<PlayerController>().health.currentHP != 0){
                subCharacterInfoSwap(3);
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<PlayerController>().controlEnabled = false;
                tempPosition = character3.GetComponent<Transform>().position;
                character3.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character3;
                // textBoxManager.player = currentCharacter.GetComponent<PlayerController>();
                // dialogueOption.player = currentCharacter.GetComponent<PlayerController>();
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<PlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            }   
        }

        public void switchToCharacter4(){
            if(currentCharacter != character4 && character4.GetComponent<PlayerController>().health.currentHP != 0){
                subCharacterInfoSwap(4);
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<PlayerController>().controlEnabled = false;
                tempPosition = character4.GetComponent<Transform>().position;
                character4.GetComponent<Transform>().position = currentCharacter.GetComponent<Transform>().position;
                currentCharacter.GetComponent<Transform>().position = tempPosition;
                currentCharacter = character4;
                // textBoxManager.player = currentCharacter.GetComponent<PlayerController>();
                // dialogueOption.player = currentCharacter.GetComponent<PlayerController>();
                currentCharacter.GetComponent<Transform>().gameObject.GetComponent<PlayerController>().controlEnabled = true;
                mainCamera.objectToFollow = currentCharacter.GetComponent<Transform>().gameObject;
                mainHealthBar.SetMaxHealth(currentCharacter.GetComponent<Health>().maxHP, currentCharacter.GetComponent<Health>().currentHP);
                mainManaBar.SetMaxMana(currentCharacter.GetComponent<Mana>().maxMP, currentCharacter.GetComponent<Mana>().currentMP);
            } 
        }

        public void onDeathSwitch(){
            if(character1.GetComponent<Health>().currentHP != 0){
                switchToCharacter1();
            } else if(character2.GetComponent<Health>().currentHP != 0){
                switchToCharacter2();
            } else if(character3.GetComponent<Health>().currentHP != 0){
                switchToCharacter3();
            } else if(character4.GetComponent<Health>().currentHP != 0){
                switchToCharacter4();
            } else {
                Debug.Log("All characters are dead");
            }
        }
    }
}