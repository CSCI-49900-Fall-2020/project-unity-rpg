using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using UnityEngine.EventSystems;
using System.Text;

[CreateAssetMenu(menuName ="Skill", fileName ="newSkill")]
public class SkillDescriptionTemp : ScriptableObject
{
    public string skillName;
    public string description;
    public string upgradeDescription;
    //public Sprite skillSprite;
    
    //public GameObject skill;
    //public int 	skillLevel = skill.GetComponent<SkillButton>().abilityLevel;
}
