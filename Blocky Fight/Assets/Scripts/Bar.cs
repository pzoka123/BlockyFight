// inScope Studios - Health Bar tutorials

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField]
    float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    Image content;

    [SerializeField]
    private Color fullColor;
    [SerializeField]
    private Color lowColor;

    [SerializeField]
    private bool lerpColors;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Convert(value);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (lerpColors)
        {
            content.color = fullColor;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
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
