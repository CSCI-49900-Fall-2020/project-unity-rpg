using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//display a line given in inspector fade in and out
public class DisplayLine : MonoBehaviour
{
    public Text displayText;
    public float displayTime;
    public int repeatNum;
    public string line;
    public bool OnTrigger;
    private IEnumerator fadeAlpha;

    void Start()
    {
        if (displayText != null && OnTrigger != true)
        {
            displayText.text = line;
            SetAlpha();
        }
    }

    void OnTriggerEnter2D()
    {
        if (displayText != null)
        {
            displayText.text = line;
            SetAlpha();
        }
    }

    void SetAlpha()
    {
        //if (fadeAlpha != null)
        //{
        //    StopCoroutine(FadeAlpha);
        //}
        fadeAlpha = FadeAlpha();
        StartCoroutine(fadeAlpha);
    }

    IEnumerator FadeAlpha()
    {
        Color originalColor = displayText.color;

        for (int k = 1; k <= repeatNum; ++k)
        {
            //fade in
            for (float i = 0; i <= displayTime; i += Time.deltaTime)
            {
                //set color with i as alpha
                displayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, i);
                //displaytext.color.a = i;
                yield return null;
            }

            //fade out
            for (float i = displayTime; i >= 0; i -= Time.deltaTime)
            {
                //set color with i as alpha
                displayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, i);
                //displaytext.color.a = i;
                yield return null;
            }
        }
    }
}
