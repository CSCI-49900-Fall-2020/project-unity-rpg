using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();

    public GameObject[] slots;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();

    public ItemRemoveButton thisButton;//which item button we are hovering
    public ItemRemoveButton[] itemButtons;//all item button in inventory


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
    }
    private void DisplayItems()
    {
      /*  for(int i = 0; i < items.Count; i++)
        {
            //set item image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //slot count text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //close button
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
        }*/

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
        for(int i = 0; i < itemButtons.Length; i++)//loop all buttons (21 in this case)
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
