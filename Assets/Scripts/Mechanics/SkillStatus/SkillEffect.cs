using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class SkillEffect : MonoBehaviour
{
	/*
	public GameObject alice;
	public GameObject bob;
	public GameObject charlie;
	public GameObject dave;
	public GameObject manager;
	*/
	public GameObject fire1;
	public GameObject fire2;
	public GameObject fire3;
	public GameObject fire4;
	public GameObject water1;
	public GameObject water2;
	public GameObject water3;
	public GameObject earth1;
	public GameObject earth2;
	public GameObject earth3;

	public void FireSkill1(){
		if (fire1.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("fire1");
		}
	}
	public void FireSkill2(){
		if (fire2.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("fire2");
		}
	}
	public void FireSkill3(){
		if (fire3.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("fire3");
		}
	}
	public void FireSkill4(){
		if (fire4.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("fire4");
		}
	}



	public void WaterEffect1(){
		if (water1.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("water1");
		}
	}
	public void WaterEffect2(){
		if (water2.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("water2");
		}
	}
	public void WaterEffect3(){
		if (water3.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("water3");
		}
	}




	public void EarthEffect1(){
		if (earth1.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("earth1");
		}
	}
	public void EarthEffect2(){
		if (earth2.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("earth2");
		}
	}
	public void EarthEffect3(){
		if (earth3.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("earth3");
		}
	}



/*
	public void AirEffect1(){
		if (air1.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("air1");
		}
	}
	public void AirEffect2(){
		if (air2.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("air2");
		}
	}
	public void AirEffect3(){
		if (air3.GetComponent<SkillButton>().abilityLevel > 0)
		{
			print("air3");
		}
	}

*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
