using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingStoreButtons : MonoBehaviour
{
    public int itemCost;
    public int slotID;
    public int value;
    public Item storeItem;
    public EquipmentItem storeEquipmentItem;
    public void UsingStoreSlot()
    {

        if (slotID == 0)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementHealth(value);
                    ScoreManager.instance.decreaseScore(itemCost);

                    if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP > GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
                    {
                        GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP;
                    }
                }
                else
                {
                    Debug.Log("Health is full");
                }
            }
        }
        else if (slotID == 1)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().setMaxHealth(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().health.maxHP + value);
                ScoreManager.instance.decreaseScore(itemCost);
            }

        }
        else if (slotID == 2)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                if (GameManager.instance.items.Count < GameManager.instance.slots.Length)
                {
                    GameManager.instance.AddItem(storeItem);
                    ScoreManager.instance.decreaseScore(itemCost);
                }
            }
        }
        else if (slotID == 3)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().currentMP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().maxMP)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementMana(value);
                    ScoreManager.instance.decreaseScore(itemCost);

                }
                else
                {
                    Debug.Log("mana is full");
                }
            }
        }
        else if (slotID == 4)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().setMaxMana(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().mana.maxMP + value);
                ScoreManager.instance.decreaseScore(itemCost);
            }
        }
        else if (slotID == 5)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {

                if (GameManager.instance.items.Count < GameManager.instance.slots.Length)
                {
                    GameManager.instance.AddItem(storeItem);
                    ScoreManager.instance.decreaseScore(itemCost);
                }
            }
        }
        else if (slotID == 6)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                //MAKE THE CHANGE FOR ALL BULLETS
                //GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().damage += value;
                ScoreManager.instance.decreaseScore(itemCost);
               // Debug.Log(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().damage);
            }
        }
        else if(slotID == 7)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<MeleeAttack>().damage += value;
                ScoreManager.instance.decreaseScore(itemCost);
                Debug.Log(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<MeleeAttack>().damage);
            }
        }
        else if(slotID == 8)
        {
            if (ScoreManager.instance.score < itemCost)
            {
                Debug.Log("dont have enought coins");
            }
            else
            {
                //MAKE THE CHANGE FOR ALL BULLETS
               // GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().damage += value;
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<MeleeAttack>().damage += value;
                ScoreManager.instance.decreaseScore(itemCost);
               // Debug.Log(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().damage);
                Debug.Log(GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<MeleeAttack>().damage);
            }
        }

    }

}
