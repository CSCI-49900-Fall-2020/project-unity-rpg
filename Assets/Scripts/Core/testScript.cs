using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("staying in ground");
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("touching ground");
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("exiting ground");
    }
}
