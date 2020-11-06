using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUsing : MonoBehaviour
{
    public int equipmentId;
    public EquipmentItem eItem;
    public Button button;

    private EquipmentItem GetThisEItem()
    {

        for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
        {
            if (equipmentId == i)
            {
                eItem = GameManager.instance.equipmentItems[i];
            }
        }
        return eItem;
    }

    public void UseEquipmentButton()
    {
        
        if (GetThisEItem().EquipmentID == 1)
        {
            Debug.Log("this happens " + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 1 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().incrementHealth(5);
                    button.enabled = false;
                    GameManager.instance.equipmentItems[i].eUsing = true;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = "USING";
                   
                }


            }



        }
        else if(GetThisEItem().EquipmentID == 5)
        {
            Debug.Log("this happens 5 " + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 5 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().incrementHealth(5);
                    button.enabled = false;
                }



            }
        }
    }

}
