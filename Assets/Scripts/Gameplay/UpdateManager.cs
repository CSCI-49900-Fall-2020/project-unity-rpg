using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class UpdateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerController>().controlEnabled){
            gameObject.GetComponent<CharacterSwapping>().currentCharacter.GetComponent<PlayerAggro>().toUpdate();
        }

        // if(Input.GetKeyDown("m")){
        //     Debug.Log(Time.deltaTime + "Before update");
        //     playerAggro.check();
        //     playerAggro.toUpdate();
        //     Debug.Log(Time.deltaTime + "After update");
        //     playerAggro.check();
        // }
    }
}
