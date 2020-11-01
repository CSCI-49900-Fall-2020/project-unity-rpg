using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EquipmentItem", fileName = "New EItem")]
public class EquipmentItem : ScriptableObject   
{
    public string itemName;
    // ID = 1 for helmet, ID = 2 for body, ID = 3 for pants, ID = 4 for shoes
    public int EquipmentID;
    public string description;
    public Sprite itemSprite;
    public int value;
    public EquipmentItem()
    {
        itemName = null;
        EquipmentID = 0;
        description = null;
        value = 0;
    }

}
