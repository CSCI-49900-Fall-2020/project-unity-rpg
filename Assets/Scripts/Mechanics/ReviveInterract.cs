using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ReviveInterract : MonoBehaviour
    {
        GameObject donut;
        CharacterSwapping characterSwapper;
        public bool triggered = false;
        GameObject Alice;
        GameObject Bob;
        GameObject Charlie;
        GameObject Dave;
        
        // Start is called before the first frame update
        void Start()
        {
            donut = GameObject.Find("Donut");
            if(donut != null){
                characterSwapper = donut.GetComponent<CharacterSwapping>();
                Alice = characterSwapper.character1;
                Bob = characterSwapper.character2;
                Charlie = characterSwapper.character3;
                Dave = characterSwapper.character4;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                triggered = true;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                triggered = false;
        }

        void Update()
        {
            if (triggered && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Full Reviving Everyone");
                Alice.GetComponent<PlayerController>().incrementHealth(Alice.GetComponent<Health>().maxHP);
                Bob.GetComponent<PlayerController>().incrementHealth(Bob.GetComponent<Health>().maxHP);
                Charlie.GetComponent<PlayerController>().incrementHealth(Charlie.GetComponent<Health>().maxHP);
                Dave.GetComponent<PlayerController>().incrementHealth(Dave.GetComponent<Health>().maxHP);
            }
        }
    }
}
