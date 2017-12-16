
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float fillAmount;
    
    public float lerpSpeed;

    public Image content;

    public Color fullColor;

    public Color lowColor;

    public bool lerpColors;

    static public float maxVal = 100;

    public float curVal;

    // Use this for initialization
    void Start()
    {
        if (lerpColors)
        {
            content.color = fullColor;
        }
        curVal = maxVal;
    }
	
    // Update is called once per frame
    void Update()
    {
        fillAmount = Convert(curVal);
        HandleBar();
    }

    void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
        if (lerpColors)
        {
            content.color = Color.Lerp(lowColor, fullColor, fillAmount);
        }
    }

    float Convert(float amount)
    {
        return amount / 100;
    }
}
