using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//designed to activate only after boss death
public class Toggle : MonoBehaviour
{

    public GameObject door;
    private GameObject enemyToKill;

    // Start is called before the first frame update
    void Start()
    {
        enemyToKill = GameObject.Find("sword_boss");
        door.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyToKill == null && door.activeInHierarchy == false)
        {
            door.SetActive(true);
        }
    }
}