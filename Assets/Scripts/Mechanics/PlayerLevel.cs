using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class PlayerLevel : MonoBehaviour
{

	public int playerLevel = 0;
	public int playerExp = 0;
	public int levelUp = 20; 
	//public GameObject skillTree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GainExp(int enemyExp)
    {
    	playerExp += enemyExp;
    	if (playerExp >= levelUp)
    	{
    		playerExp -= levelUp;
    		levelUp += 12;
    		gameObject.GetComponent<SkillTree>().abilityPoints += 1 ;
    	}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
