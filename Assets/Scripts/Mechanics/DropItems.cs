using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public bool drops;
    public GameObject theDrops;
    public Transform dropPoint;
    public SpriteRenderer sr;
    
    public void Update()
    {
        
        if (sr == false)
        { 
            if (drops) Instantiate(theDrops,dropPoint.position,dropPoint.rotation);
        }
    }

}
