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
	public GameObject canvasSet;
	void Update()
	{
	  	if(Input.GetKeyDown("t"))
	  	{
	  		gameObject.GetComponent<SkillTree>().DisplayAbilityPoints();
	    	if(skillTreeUI.activeSelf)
	    	{
	      		skillTreeUI.SetActive(false);
				canvasSet.SetActive(true);

			}
			else 
	    	{
	      		skillTreeUI.SetActive(true);
				canvasSet.SetActive(false);
			}
	  	}
	}
}
