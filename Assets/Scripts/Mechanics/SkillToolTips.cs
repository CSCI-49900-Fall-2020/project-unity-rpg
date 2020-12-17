using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class SkillToolTips : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public ToolTips tooltip;
    private Vector2 position;
    public string skillName = "NA";
    public string skillDescription = "NA";
    public string skillBonus = "NA";

    public void OnPointerEnter(PointerEventData eventData)
    {
    	ShowText();
    }

	public void UseButton()
	{
		ShowText();
	}

    public void OnPointerExit(PointerEventData eventData)
    {
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");
    }

    private string GetDetailText()
    {
    	 StringBuilder stringBuilder = new StringBuilder();
         stringBuilder.AppendFormat("Skill:"+skillName+" \n");
         stringBuilder.AppendFormat("Current Level:"+gameObject.GetComponent<SkillButton>().abilityLevel+" \n");
         stringBuilder.AppendFormat(skillDescription+skillBonus+"\n");
         stringBuilder.AppendFormat("Next Level: "+(gameObject.GetComponent<SkillButton>().abilityLevel+1)+"\n");
         stringBuilder.AppendFormat(skillDescription+skillBonus+"\n");

         return stringBuilder.ToString();
    }

    public void ShowText()
    {
	    tooltip.ShowTooltip();
        tooltip.UpdateTooltip(GetDetailText());
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as 
        RectTransform, Input.mousePosition,null,out position);

        tooltip.SetPosition(position);
    }
}
