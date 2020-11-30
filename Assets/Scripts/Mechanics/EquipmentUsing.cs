using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        //if equiptment 
        if (GetThisEItem().EquipmentID == 1)
        {
            Debug.Log("this happens  1" + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 1 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().InsertEquipmentItemToPlayer(GetThisEItem());
                    // Debug.Log("Name: " + GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().name);
                    button.enabled = false;
                    //add in other if statments
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    GameManager.instance.equipmentItems[i].eItemUsedByCharacter = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    Debug.Log("name: " + GameManager.instance.equipmentItems[i].eItemUsedByCharacter);
                    Debug.Log(eItem.itemName);
                    for (int j = 0; j < GameManager.instance.equipmentHelmets.Count; j++)
                    {
                        if (!(GameManager.instance.equipmentHelmets[j].itemName == eItem.itemName) && GameManager.instance.equipmentHelmets[j].eItemUsedByCharacter == eItem.eItemUsedByCharacter)
                        {
                            for (int k = 0; k < GameManager.instance.equipmentSlots.Length; k++)
                            {
                                if (k < GameManager.instance.equipmentItems.Count)
                                {
                                    if (GameManager.instance.equipmentHelmets[j].itemName == GameManager.instance.equipmentItems[k].itemName)
                                    {
                                        Debug.Log("Item Name: " + GameManager.instance.equipmentItems[k].itemName);
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).GetComponent<Button>().enabled = true;
                                        GameManager.instance.equipmentItems[k].eItemUsedByCharacter = null;
                                    }

                                }
                            }

                        }
                    }

                }


            }
        }
        else if (GetThisEItem().EquipmentID == 2)
        {
            Debug.Log("this happens  2" + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 2 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().InsertEquipmentItemToPlayer(GetThisEItem());
                    // Debug.Log("Name: " + GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().name);
                    button.enabled = false;

                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    GameManager.instance.equipmentItems[i].eItemUsedByCharacter = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;

                    for (int j = 0; j < GameManager.instance.equipmentChest.Count; j++)
                    {
                        if (!(GameManager.instance.equipmentChest[j].itemName == eItem.itemName) && GameManager.instance.equipmentHelmets[j].eItemUsedByCharacter == eItem.eItemUsedByCharacter)
                        {


                            for (int k = 0; k < GameManager.instance.equipmentSlots.Length; k++)
                            {
                                if (k < GameManager.instance.equipmentItems.Count)
                                {
                                    if (GameManager.instance.equipmentChest[j].itemName == GameManager.instance.equipmentItems[k].itemName)
                                    {
                                        Debug.Log("Item Name: " + GameManager.instance.equipmentItems[k].itemName);
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).GetComponent<Button>().enabled = true;
                                        GameManager.instance.equipmentItems[k].eItemUsedByCharacter = null;
                                    }

                                }
                            }

                        }
                    }

                }


            }
        }
        else if (GetThisEItem().EquipmentID == 3)
        {
            Debug.Log("this happens  3" + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 3 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().InsertEquipmentItemToPlayer(GetThisEItem());
                    // Debug.Log("Name: " + GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().name);
                    button.enabled = false;

                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    GameManager.instance.equipmentItems[i].eItemUsedByCharacter = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    for (int j = 0; j < GameManager.instance.equipmentPants.Count; j++)
                    {
                        if (!(GameManager.instance.equipmentPants[j].itemName == eItem.itemName) && GameManager.instance.equipmentHelmets[j].eItemUsedByCharacter == eItem.eItemUsedByCharacter)
                        {


                            for (int k = 0; k < GameManager.instance.equipmentSlots.Length; k++)
                            {
                                if (k < GameManager.instance.equipmentItems.Count)
                                {
                                    if (GameManager.instance.equipmentPants[j].itemName == GameManager.instance.equipmentItems[k].itemName)
                                    {
                                        Debug.Log("Item Name: " + GameManager.instance.equipmentItems[k].itemName);
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).GetComponent<Button>().enabled = true;
                                        GameManager.instance.equipmentItems[k].eItemUsedByCharacter = null;
                                    }

                                }
                            }

                        }
                    }

                }
            }
        }
        else if (GetThisEItem().EquipmentID == 4)
        {
            Debug.Log("this happens  4" + GetThisEItem().itemName);
            for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 4 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                    GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().InsertEquipmentItemToPlayer(GetThisEItem());
                    // Debug.Log("Name: " + GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().name);

                    button.enabled = false;

                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    GameManager.instance.equipmentItems[i].eItemUsedByCharacter = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    for (int j = 0; j < GameManager.instance.equipmentBoots.Count; j++)
                    {
                        if (!(GameManager.instance.equipmentBoots[j].itemName == eItem.itemName) && GameManager.instance.equipmentHelmets[j].eItemUsedByCharacter == eItem.eItemUsedByCharacter)
                        {


                            for (int k = 0; k < GameManager.instance.equipmentSlots.Length; k++)
                            {
                                if (k < GameManager.instance.equipmentItems.Count)
                                {
                                    if (GameManager.instance.equipmentBoots[j].itemName == GameManager.instance.equipmentItems[k].itemName)
                                    {
                                        Debug.Log("Item Name: " + GameManager.instance.equipmentItems[k].itemName);
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).GetComponent<Button>().enabled = true;
                                        GameManager.instance.equipmentItems[k].eItemUsedByCharacter = null;
                                    }
                                }
                            }

                        }
                    }

                }
            }
        }
        else if (GetThisEItem().EquipmentID == 5)
        {
            Debug.Log("this happens  5" + GetThisEItem().itemName);
           /* for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
            {
                if (GameManager.instance.equipmentItems[i].EquipmentID == 5 && GameManager.instance.equipmentItems[i].itemName == eItem.itemName)
                {
                   // GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerAttributes>().playerDamage += GetThisEItem().value;
                    // Debug.Log("Name: " + GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().name);

                    button.enabled = false;

                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    GameManager.instance.equipmentSlots[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                    GameManager.instance.equipmentItems[i].eItemUsedByCharacter = GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Character>().characterName;
                    for (int j = 0; j < GameManager.instance.equipmentBoots.Count; j++)
                    {
                        if (!(GameManager.instance.equipmentBoots[j].itemName == eItem.itemName) && GameManager.instance.equipmentHelmets[j].eItemUsedByCharacter == eItem.eItemUsedByCharacter)
                        {


                            for (int k = 0; k < GameManager.instance.equipmentSlots.Length; k++)
                            {
                                if (k < GameManager.instance.equipmentItems.Count)
                                {
                                    if (GameManager.instance.equipmentBoots[j].itemName == GameManager.instance.equipmentItems[k].itemName)
                                    {
                                        Debug.Log("Item Name: " + GameManager.instance.equipmentItems[k].itemName);
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = " ";
                                        GameManager.instance.equipmentSlots[k].transform.GetChild(2).GetComponent<Button>().enabled = true;
                                        GameManager.instance.equipmentItems[k].eItemUsedByCharacter = null;
                                    }
                                }
                            }

                        }
                    }

                }
            }*/
        }
    }

}
