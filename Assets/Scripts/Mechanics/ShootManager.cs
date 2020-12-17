using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.UI;
public class ShootManager : MonoBehaviour
{
    //should be merged with button manager but I want to avoid merge conflicts 
    // Start is called before the first frame update
    KeyBinds keyBinds;
    void Start()
    {
        keyBinds = GameObject.FindObjectOfType<KeyBinds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyBinds.GetButtonDown("Skill2"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(1);
        }
        if (keyBinds.GetButtonDown("Skill3"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(2);
        }
        if (keyBinds.GetButtonDown("Skill4"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(3);
        }
        if (keyBinds.GetButtonDown("Skill1"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(4);
        }
    }
}