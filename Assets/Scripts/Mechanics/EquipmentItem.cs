using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "EquipmentItem", fileName = "New EItem")]
public class EquipmentItem : ScriptableObject   
{
    public string itemName;
    // ID = 1 for helmet, ID = 2 for chest, ID = 3 for pants, ID = 4 for boots , ID = 5 for weapon
    public int EquipmentID;
    public string description;
    public Sprite itemSprite;
    public int value;
    public bool eUsing;
<<<<<<< HEAD
    public string eItemUsedByCharacter;
=======
>>>>>>> de29b0b38b3064d0dc41cae3680f750ec4f0b40f
    public EquipmentItem()
    {
        itemName = null;
        EquipmentID = 0;
        description = null;
        value = 0;
        eUsing = false;
    }

}
