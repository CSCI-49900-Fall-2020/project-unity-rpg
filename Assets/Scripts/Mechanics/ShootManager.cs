using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class ShootManager : MonoBehaviour
{
    //should be merged with button manager but I want to avoid merge conflicts 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("/"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(1);
        }
        if (Input.GetKey ("j"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(2);
        }
        if (Input.GetKey ("k"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(3);
        }
        if (Input.GetKey ("l"))
        {
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerDetectShoot>().ShootBulletButton(4);
        }
    }
}
