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
            if (GameManager.instance.playerC.GetComponent<Health>().currentHP < GameManager.instance.playerC.GetComponent<Health>().maxHP)
            {
                GameManager.instance.RemoveItem(GetThisItem());
                GameManager.instance.playerC.GetComponent<Health>().currentHP += 10;
                if (GameManager.instance.playerC.GetComponent<Health>().currentHP > GameManager.instance.playerC.GetComponent<Health>().maxHP)
                {
                    GameManager.instance.playerC.GetComponent<Health>().currentHP = GameManager.instance.playerC.GetComponent<Health>().maxHP;
                }
            }
            else
            {
                Debug.Log("Health is full");
            }
        }
        else if (GetThisItem().itemName.Equals("Cookie")) {
            if (GameManager.instance.playerC.GetComponent<Mana>().currentMP < GameManager.instance.playerC.GetComponent<Mana>().maxMP)
            {
                GameManager.instance.RemoveItem(GetThisItem());
                GameManager.instance.playerC.GetComponent<Mana>().currentMP += 1;
                if (GameManager.instance.playerC.GetComponent<Mana>().currentMP > GameManager.instance.playerC.GetComponent<Mana>().maxMP)
                {
                    GameManager.instance.playerC.GetComponent<Mana>().currentMP = GameManager.instance.playerC.GetComponent<Mana>().maxMP;
                }
            }
            else
            {
                Debug.Log("Mana is full");
            }

        }

    }


}
