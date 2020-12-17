﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
	public class SkillTree : MonoBehaviour
	{
		public int abilityPoints = 5;
		public SkillButton[] sTree;
		public Text visualPoints;

		void Awake()
		{
			visualPoints.text = "Skill Points Left = " + abilityPoints;
		}

		public bool UpgradeSkill(){
			if (abilityPoints > 0)
			{ 
				abilityPoints = abilityPoints - 1; 
				visualPoints.text = "Skill Points Left = " + abilityPoints;
				return true;
			}else
			{
				print("We Require More Skill Points");
				return false;
			}
		}

		public void SkillReset()
		{
	        for (int i = 0; i < sTree.Length; i++)
           {     
				abilityPoints += sTree[i].abilityLevel;
				sTree[i].abilityLevel = 0;
				sTree[i].SetDefault();
			}
		}

		public void UseButton(){
			SkillReset();
			visualPoints.text = "Skill Points Left = " + abilityPoints;
		}
	}
}