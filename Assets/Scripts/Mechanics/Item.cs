﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Item", fileName ="New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite itemSprite;
    public int value;
    public string modify;


}
