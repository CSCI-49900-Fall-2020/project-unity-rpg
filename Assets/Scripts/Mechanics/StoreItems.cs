using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "StoreItem", fileName = "New Store Item")]
public class StoreItems : ScriptableObject
{
    public string storeItemDescription;
    public int storeItemCost;
    public Item storeConsumable = null;
    public EquipmentItem storeEquipment = null;
    public string storeSlotValue;
}
