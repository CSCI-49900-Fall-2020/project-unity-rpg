using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
	public GameObject[] previousReq;
	public GameObject[] nextReq;
	bool skillPlus1 = false;

	public int abilityLevel = 0;
	public GameObject skillTree;

	public int abilityLevelReq = 1;
	public bool unlockThisSkill = false;
	public bool unlockNextSkill = false;
	public string skilButtonID;
	
	public void SetDefault()
	{
		unlockThisSkill = false;
		unlockNextSkill = false;
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

	void Start()
	{
		SetDefault();
	}

	public void UnlockCurrentTeir()
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
				GetComponent<Image>().color = new Color (.5f, .5f, .5f, 1);
				return;
			}
		}
		unlockThisSkill = true;
		GetComponent<Image>().color = new Color (1, 1, 1, 1);
		return;	
	}

	public void UnlockNextTeir()
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
		if (unlockThisSkill == true)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
