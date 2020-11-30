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
        if (GetThisItem().modify.Equals("health"))
        {
            if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
            {

                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementHealth(GetThisItem().value);
                Debug.Log(GetThisItem().itemName);
                GameManager.instance.RemoveItem(GetThisItem());
<<<<<<< HEAD
                if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP > GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP;
=======
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementHealth(GetThisItem().value);
                if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP > GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP)
                {
                   GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().currentHP = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().maxHP;
>>>>>>> de29b0b38b3064d0dc41cae3680f750ec4f0b40f
                }
            }
            else
            {
                Debug.Log("Health is full");
            }
        }
<<<<<<< HEAD

        else if (GetThisItem().modify.Equals("mana"))
        {
=======
        else if (GetThisItem().itemName.Equals("Cookie")) {
>>>>>>> de29b0b38b3064d0dc41cae3680f750ec4f0b40f
            if (GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().currentMP < GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Mana>().maxMP)
            {

                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementMana(GetThisItem().value);
                GameManager.instance.RemoveItem(GetThisItem());
<<<<<<< HEAD
=======
                GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().incrementMana(GetThisItem().value);
>>>>>>> de29b0b38b3064d0dc41cae3680f750ec4f0b40f
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
