using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTips : MonoBehaviour
{
    public Text detailText;

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowTooltip()
    {
        gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void UpdateTooltip(string newDetailText)
    {
        detailText.text = newDetailText;
    }
    public void SetPosition(Vector2 nPosition)
    {
        transform.localPosition = nPosition; 
    }

}
