using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Item itemData;
    public EquipmentItem equipmentData;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {


            if (collision.tag == "Player" && this.tag == "InventoryItems")
            {
                if (GameManager.instance.items.Count < GameManager.instance.slots.Length)
                {
                    Destroy(gameObject);
                    GameManager.instance.AddItem(itemData);
                }
                else
                {
                    Debug.Log("Inventory is full!. Can't pick up more items!");
                }
            }
            else if (this.tag == "EquipmentTags" && collision.tag == "Player")
            {
                if (GameManager.instance.AddEquipmentItem(equipmentData))
                {
                    Destroy(gameObject);
<<<<<<< HEAD
                    
=======
                    Debug.Log("si debe destruir");
>>>>>>> de29b0b38b3064d0dc41cae3680f750ec4f0b40f
                }
            }
        
        
    }

}
