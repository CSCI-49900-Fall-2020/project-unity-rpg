using JetBrains.Annotations;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public List<EquipmentItem> equipmentItems = new List<EquipmentItem>();
    public GameObject[] equipmentSlots;
    public EquipmentRemoveButton[] equipmentButton;
    
    
    public Sprite equipmentSprite;

    public GameObject playerC;
    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();

    public ItemRemoveButton thisButton;//which item button we are hovering
    public ItemRemoveButton[] itemButtons;//all item button in inventory

    


    //list of each equipment  helmet = 1, body = 2, pants = 3, boots = 4, sword = 5

    public List<EquipmentItem> equipmentHelmets = new List<EquipmentItem>();
    public List<EquipmentItem> equipmentChest = new List<EquipmentItem>();  
    public List<EquipmentItem> equipmentPants = new List<EquipmentItem>();  
    public List<EquipmentItem> equipmentBoots = new List<EquipmentItem>();   
    public List<EquipmentItem> equipmentWeapon = new List<EquipmentItem>();
  
    //public List<EquipmentItem> currentEquipmentsUsing = new List<EquipmentItem>();





    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }


    public void Start()
    {
        DisplayItems();
        DisplayEquipmentItem();
    }

   


    public void DisplayItems()
    {

        for(int i = 0;i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                //set item image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //slot count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //close button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);

                //use button
                slots[i].transform.GetChild(3).gameObject.SetActive(true);


            }
            else
            {
                //set item image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //slot count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //close button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
               
                //use button
                slots[i].transform.GetChild(3).gameObject.SetActive(false);
            }
        }


    }
  

    public void AddItem(Item nItem)
    {
        //if there is a new item in the inventory
        if (!items.Contains(nItem))
        {
            items.Add(nItem);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("you already have this items");
            for(int i = 0; i < items.Count;i++)
            {
                if(nItem == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }

        DisplayItems();
    }

    public bool AddEquipmentItem(EquipmentItem eItem)
    {
        if (equipmentItems.Contains(eItem))
        {
            Debug.Log("you already have this equipment item!");
            return false;
        }
        else
        {
            if (eItem.EquipmentID == 1)
            {
                    equipmentHelmets.Add(eItem);
                    equipmentItems.Add(eItem);
                    DisplayEquipmentItem();
                    return true;
                
            }
            else if (eItem.EquipmentID == 2)
            {
               
                    equipmentChest.Add(eItem);
                    equipmentItems.Add(eItem);
                    DisplayEquipmentItem();
                    return true;
                
            }
            else if (eItem.EquipmentID == 3)
            {
                
                    equipmentPants.Add(eItem);
                    equipmentItems.Add(eItem);
                    DisplayEquipmentItem();
                    return true;
                    
            }
            else if (eItem.EquipmentID == 4)
            {

                    equipmentBoots.Add(eItem);
                    equipmentItems.Add(eItem);
                    DisplayEquipmentItem();
                    return true;
                
            }
            else if (eItem.EquipmentID == 5)
            {
               
                    equipmentWeapon.Add(eItem);
                    equipmentItems.Add(eItem);
                    DisplayEquipmentItem();
                    return true;
                
            }
            else
            {
                Debug.Log("this IDEquipment is not allowed");
                return false;
            }
        }
    }



    public void DisplayEquipmentItem()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (i < equipmentItems.Count)
            {
              
               // equipmentSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
               // equipmentSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = equipmentItems[i].itemSprite;

                equipmentSlots[i].transform.GetChild(1).gameObject.SetActive(true);

                equipmentSlots[i].transform.GetChild(2).GetComponent<Button>().image.sprite = equipmentItems[i].itemSprite;
                if (equipmentItems[i].eUsing)
                {
                    equipmentSlots[i].transform.GetChild(2).GetComponent<Button>().enabled = false;
                    equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = equipmentItems[i].eItemUsedByCharacter;
                }
                else
                {
                    equipmentSlots[i].transform.GetChild(2).GetComponent<Button>().enabled = true;
                    equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                }
             /*   if (equipmentItems[i].eUsing)
                {
                    equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                }*/


            }
            else
            {
                equipmentSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                equipmentSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                equipmentSlots[i].transform.GetChild(1).gameObject.SetActive(false);
                equipmentSlots[i].transform.GetChild(2).GetComponent<Button>().image.sprite = equipmentSprite;
                equipmentSlots[i].transform.GetChild(2).GetComponent<Button>().enabled = false;
                equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";

            }
        }
    }
    

    public void RemoveEquipmentItem(EquipmentItem eitem)
    {
       //remove text "using" here
       //equipmentSlots[eitem.EquipmentID].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 0);
        equipmentItems.Remove(eitem);
        RemovingEquipmentItemFromOtherCharacter(eitem);
        ResetButtonEquipmentItems();
        DisplayEquipmentItem();
    }
   public void RemovingEquipmentItemFromOtherCharacter(EquipmentItem rEitem)
    {
        if (playerC.GetComponent<CharacterSwapping>().character1.GetComponent<PlayerController>().playerCurrentEitems.Contains(rEitem))
        {
            playerC.GetComponent<CharacterSwapping>().character1.GetComponent<PlayerController>().setMaxHealth(playerC.GetComponent<CharacterSwapping>().character1.GetComponent<PlayerController>().health.maxHP - rEitem.value);
            playerC.GetComponent<CharacterSwapping>().character1.GetComponent<PlayerController>().playerCurrentEitems.Remove(rEitem);
        }
        else if (playerC.GetComponent<CharacterSwapping>().character2.GetComponent<PlayerController>().playerCurrentEitems.Contains(rEitem))
        {
            playerC.GetComponent<CharacterSwapping>().character2.GetComponent<PlayerController>().setMaxHealth(playerC.GetComponent<CharacterSwapping>().character2.GetComponent<PlayerController>().health.maxHP - rEitem.value);
            playerC.GetComponent<CharacterSwapping>().character2.GetComponent<PlayerController>().playerCurrentEitems.Remove(rEitem);
        }
        else if (playerC.GetComponent<CharacterSwapping>().character3.GetComponent<PlayerController>().playerCurrentEitems.Contains(rEitem))
        {
            playerC.GetComponent<CharacterSwapping>().character3.GetComponent<PlayerController>().setMaxHealth(playerC.GetComponent<CharacterSwapping>().character3.GetComponent<PlayerController>().health.maxHP - rEitem.value);
            playerC.GetComponent<CharacterSwapping>().character3.GetComponent<PlayerController>().playerCurrentEitems.Remove(rEitem);
        }
        else if (playerC.GetComponent<CharacterSwapping>().character4.GetComponent<PlayerController>().playerCurrentEitems.Contains(rEitem))
        {
            playerC.GetComponent<CharacterSwapping>().character4.GetComponent<PlayerController>().setMaxHealth(playerC.GetComponent<CharacterSwapping>().character4.GetComponent<PlayerController>().health.maxHP - rEitem.value);
            playerC.GetComponent<CharacterSwapping>().character4.GetComponent<PlayerController>().playerCurrentEitems.Remove(rEitem);
        }
        
    }
    public void ResetButtonEquipmentItems()
    {
        for (int i = 0; i < equipmentButton.Length; i++ )
        {
            if (i < equipmentItems.Count)
            {
                equipmentButton[i].equipItem = equipmentItems[i];
            }
            else
            {
                equipmentButton[i].equipItem = null;
                
            }
        }
    }

    public void RemoveItem(Item nitem)
    {
        if (items.Contains(nitem))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(nitem == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        items.Remove(nitem);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("there is no" + nitem + "in the inventory");
        }

        ResetButtonItems();
        DisplayItems();
    }



    public void ResetButtonItems()
    {
        for(int i = 0; i < itemButtons.Length; i++)//loop all buttons (16 in this case)
        {
            if (i < items.Count)
            {
                itemButtons[i].thisItem = items[i];//once this btton contains the item, assign the item to thisitem
            }
            else
            {
                itemButtons[i].thisItem = null;//otherwise set the thisitem to null
            }
        }
    }

}
