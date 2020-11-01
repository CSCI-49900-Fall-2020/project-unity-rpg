using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public GameObject skillTreeUI;

	void Update()
	{
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
