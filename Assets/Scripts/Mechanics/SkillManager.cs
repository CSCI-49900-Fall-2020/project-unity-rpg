using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public GameObject skillTreeUI;
	void Update()
	{
		if(Input.GetKeyDown("y"))
		{
			Debug.Log("gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton()");
		}
	  	if(Input.GetKeyDown("t"))
	  	{
	    	if(skillTreeUI.activeSelf)
	    	{
	      		skillTreeUI.SetActive(false);
	    	}else 
	    	{
	      		skillTreeUI.SetActive(true);
	    	}
	  	}
	}
}
