using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemButton : MonoBehaviour
{
    public int buttonID;
    public Item thisItem;

    private Item GetThisItem()
    {

        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if (buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }
        }

        return thisItem;
    }


    public void UseButton()
    {
        if (GetThisItem().itemName.Equals("Potion"))
        {
            if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
            {
                GameManager.instance.RemoveItem(GetThisItem());
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementHealth(GetThisItem().value);
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
        else if (GetThisItem().itemName.Equals("Cookie")) {
            if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().currentMP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().maxMP)
            {
                GameManager.instance.RemoveItem(GetThisItem());
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementMana(GetThisItem().value);
                if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().currentMP > GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().maxMP)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().currentMP = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().maxMP;
                }
            }
            else
            {
                Debug.Log("Mana is full");
            }

        }

    }


}
