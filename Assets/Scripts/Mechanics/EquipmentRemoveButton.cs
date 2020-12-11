using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using Platformer.Mechanics;

public class EquipmentRemoveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int EquipmentIDButton;
    public EquipmentItem equipItem;

    public ToolTips toolT;
    private Vector2 position;

    private EquipmentItem GetEItem()
    {
        for (int i = 0; i < GameManager.instance.equipmentItems.Count; i++)
        {
            if (EquipmentIDButton == i)
            {
                equipItem = GameManager.instance.equipmentItems[i];
            }
        }

        return equipItem;
    }

    public void ECloseButton()
    {

        //GameManager.instance.playerC.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<Health>().GetComponent<PlayerController>().removeEquipmentItemFromPlayer(GetEItem());
        GameManager.instance.RemoveEquipmentItem(GetEItem());
        Debug.Log("removing");
        equipItem = GetEItem();
        if (equipItem != null)
        {
            //show tooltip
            toolT.ShowTooltip();
            toolT.UpdateTooltip(GetDetailText(equipItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as
                RectTransform, Input.mousePosition, null, out position);
            toolT.SetPosition(position);
        }
        else
        {
            //hide tooptip
            toolT.HideTooltip();
            toolT.UpdateTooltip("");
        }



    }




    public void OnPointerEnter(PointerEventData eventData)
    {
        GetEItem();

        if (equipItem != null)
        {
            Debug.Log("ENTER " + equipItem.itemName + " Slot");

            toolT.ShowTooltip();
            toolT.UpdateTooltip(GetDetailText(equipItem));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as
                RectTransform, Input.mousePosition, null, out position);
            toolT.SetPosition(position);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // if (thisItem != null)
        //   {
        //   Debug.Log("EXIT " + thisItem.itemName + " Slot");

        toolT.HideTooltip();
        toolT.UpdateTooltip("");

        //  }
    }

    private string GetDetailText(EquipmentItem newItem)
    {
        if (newItem == null)
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
