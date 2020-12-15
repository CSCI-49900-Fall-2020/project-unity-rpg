﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();
    }
    public void decreaseScore(int coinV)
    {
        score -= coinV;
        text.text = "X" + score.ToString();
    }
    public void setValueAndText(int value)
    {
        score = value;
        text.text = "X" + score.ToString();
    }
}
