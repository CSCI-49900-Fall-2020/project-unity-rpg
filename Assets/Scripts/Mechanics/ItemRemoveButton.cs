using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class ItemRemoveButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public ToolTips tooltip;
    private Vector2 position;


    //remove item on this button
    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }
        }
        return thisItem;
    }


    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem());

        thisItem = GetThisItem();
        if(thisItem != null)
        {
            //show tooltip
            tooltip.ShowTooltip();
            tooltip.UpdateTooltip(GetDetailText(thisItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as
                RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }
        else
        {
            //hide tooptip
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();

        if (thisItem != null)
        {
            Debug.Log("ENTER " + thisItem.itemName + " Slot");

            tooltip.ShowTooltip();
            tooltip.UpdateTooltip(GetDetailText(thisItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as 
                RectTransform, Input.mousePosition,null,out position);
            tooltip.SetPosition(position);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // if (thisItem != null)
     //   {
         //   Debug.Log("EXIT " + thisItem.itemName + " Slot");

            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");

      //  }
    }

    private string GetDetailText(Item newItem)
    {
        if(newItem == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Item: {0}\n\n", newItem.itemName);
            stringBuilder.AppendFormat("Description: {0}\n\n", newItem.description);

            return stringBuilder.ToString();
        }
    }
}
