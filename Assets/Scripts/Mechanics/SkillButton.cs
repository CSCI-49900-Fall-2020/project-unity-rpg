using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;

public class SkillButton : MonoBehaviour  ,IPointerEnterHandler, IPointerExitHandler
{
	private Vector2 position;
	public ToolTips tooltip;
	public GameObject[] previousReq;
	public GameObject[] nextReq;
	bool skillPlus1 = false;

	public int abilityLevel = 0;
	public GameObject skillTree;

	int abilityLevelReq = 3;
	bool unlockThisSkill = false;
	bool unlockNextSkill = false;
		
	void Start()
	{
		if(previousReq == null || previousReq.Length == 0)
		{
			unlockThisSkill = true;
		}

		if(unlockThisSkill == true){
			GetComponent<Image>().color = new Color (1, 1, 1, 1);
		}else
		{
			GetComponent<Image>().color = new Color (.5f, .5f, .5f, 1);
		}
	}

	void UnlockCurrentTeir()
	{
		if(previousReq == null)
		{
			unlockThisSkill = true;
			GetComponent<Image>().color = new Color (1, 1, 1, 1);
			return;
		}
		for (int i = 0; i < previousReq.Length; i++)
		{
			if(previousReq[i].GetComponent<SkillButton>().unlockNextSkill == false)
			{
				unlockThisSkill = false;
				return;
			}
		}
		unlockThisSkill = true;
		GetComponent<Image>().color = new Color (1, 1, 1, 1);
		return;	
	}

	void UnlockNextTeir()
	{
		if(abilityLevel == abilityLevelReq)
		{
			unlockNextSkill = true;
		}

		for (int i = 0; i < nextReq.Length; i++)
		{
			nextReq[i].GetComponent<SkillButton>().UnlockCurrentTeir();
		}
	}

	void OnMouseDown()
	{
		if (unlockThisSkill == false)
		{
			//holding left click colors red trying to upgrade a locked skill
			GetComponent<Image>().color = new Color (1, 0, 0, 1);
		}
		else
		{
			if (skillTree.GetComponent<SkillTree>().abilityPoints != 0)
			{
				//holding left click this colors green upgrading a skill
				GetComponent<Image>().color = new Color (0, 1, 0, 1);
			}	
			else
			{
				//holding left click this colors red upgrading a skill without any points left
				GetComponent<Image>().color = new Color (1, 0, 0, 1);
			}
		}
	}

	public void UseButton()
	{
/*
		if (unlockThisSkill == false)
		{
			//releasing left mouse click will change icon to grey scale if skill is locked
			GetComponent<Image>().color = new Color (.5f, .5f, .5f, 1);
		}
		else
		{
			//releasing left mouse click will change icon to normal color scale if skill is unlocked
			GetComponent<Image>().color = new Color (1, 1, 1, 1);
		}
*/			if (unlockThisSkill == true)
		{
			//if skill is unlocked, then you decuct a point from skill tree
			skillPlus1 = skillTree.GetComponent<SkillTree>().UpgradeSkill();
		}

		if(skillPlus1 == true)
		{
			abilityLevel = abilityLevel + 1;
			UnlockNextTeir();
			UnlockCurrentTeir();
			skillPlus1 = false;
		}
	}

	public SkillDescriptionTemp skillPlan;

	public void OnPointerEnter(PointerEventData eventData)
	{
        if (skillPlan != null)
        {

            tooltip.ShowTooltip();
            tooltip.UpdateTooltip(GetDetailText(skillPlan));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as 
            RectTransform, Input.mousePosition,null,out position);
            tooltip.SetPosition(position);
        }
	}

    public void OnPointerExit(PointerEventData eventData)
    {
            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");
    }

    private string GetDetailText(SkillDescriptionTemp skillDetail)
    {
        if(skillDetail == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Skill: {0}\n\n", skillDetail.skillName);
            stringBuilder.AppendFormat("Description: {0}\n\n", skillDetail.description);
            stringBuilder.AppendFormat("Upgraded: {0}\n\n", skillDetail.upgradeDescription);
            return stringBuilder.ToString();
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
