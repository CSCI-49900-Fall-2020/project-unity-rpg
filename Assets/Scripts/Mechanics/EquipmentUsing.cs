using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUsing : MonoBehaviour
{
    public int equipmentID;
    public EquipmentItem eItem;

    private EquipmentItem GetThisEItem()
    {

        for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
        {
            if (equipmentID == i)
            {
                eItem = GameManager.instance.equipmentItems[i];
            }
        }
        return eItem;
    }

    public void UseEquipmentButton()
    {
        //fix this
        if (GetThisEItem().EquipmentID == 1)
        {
          
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 1 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<Health>().maxHP += eItem.value;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1,1,1,1);
                }
                else if (GameManager.instance.equipmentItems[i].EquipmentID == 1 && !(GameManager.instance.equipmentItems[i].itemName == eItem.itemName))
                {
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                }
            }
        }
    }

}
