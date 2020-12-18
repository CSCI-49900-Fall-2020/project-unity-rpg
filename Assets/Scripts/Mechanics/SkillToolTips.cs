using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class SkillToolTips : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public ToolTips tooltip;
    private Vector2 position;
    public int bonus = 1;
    public int abilityLevel =0;
    public string skillName;
    public string skillDescription;
    public string skillBonus;

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
        abilityLevel = gameObject.GetComponent<SkillButton>().abilityLevel;
    	 StringBuilder stringBuilder = new StringBuilder();
         stringBuilder.AppendFormat("Skill: "           +skillName                  +" \n");
         stringBuilder.AppendFormat("Current Level: "   +abilityLevel               +" \n");
         stringBuilder.AppendFormat(skillDescription    +"\n");
         stringBuilder.AppendFormat(skillBonus          +(abilityLevel*bonus)       +"\n\n");
         stringBuilder.AppendFormat("Next Level: "      +(1+abilityLevel)           +"\n");
         stringBuilder.AppendFormat(skillBonus          +((1+abilityLevel)*bonus)   +"\n");

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
