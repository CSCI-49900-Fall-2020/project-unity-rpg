using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class SkillButton : MonoBehaviour
{
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
				GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
			}else
			{
				GetComponent<SpriteRenderer>().color = new Color (.5f, .5f, .5f, 1);
			}
		}

		void UnlockCurrentTeir()
		{
			if(previousReq == null)
			{
				unlockThisSkill = true;
				GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
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
			GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
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
				GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1);
			}
			else
			{
				if (skillTree.GetComponent<SkillTree>().abilityPoints != 0)
					//holding left click this colors green upgrading a skill
					GetComponent<SpriteRenderer>().color = new Color (0, 1, 0, 1);
				else
					//holding left click this colors red upgrading a skill without any points left
					GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, 1);
			}
		}

		void OnMouseUp()
		{
			if (unlockThisSkill == false)
			{
				//releasing left mouse click will change icon to grey scale if skill is locked
				GetComponent<SpriteRenderer>().color = new Color (.5f, .5f, .5f, 1);
			}
			else
			{
				//releasing left mouse click will change icon to normal color scale if skill is unlocked
				GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, 1);
			}
			skillPlus1 = skillTree.GetComponent<SkillTree>().UpgradeSkill();


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
