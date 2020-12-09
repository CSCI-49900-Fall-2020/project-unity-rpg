using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
	public class SkillTree : MonoBehaviour
	{
		public int abilityPoints = 5;
		public SkillButton[] sTree;
		public bool UpgradeSkill(){
			if (abilityPoints > 0)
			{
				abilityPoints = abilityPoints - 1; 
				//print("Skill Points Left: "+ abilityPoints);

				return true;
			}else
			{
				print("We Require More Skill Points");
				return false;
			}
		}
	}
}