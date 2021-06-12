using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGrowShrink : MonoBehaviour
{
    private RectTransform rectTransform;
    private bool isShrunkAndInactive = false;

    void Start()
    {
        if(this.GetComponent<RectTransform>() != null)
        {
            rectTransform = this.GetComponent<RectTransform>();
        }
    }

    void OnEnable()
    {
        Shrink();
    }

    public void Grow()
    {
        if(rectTransform)
        {
            rectTransform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
    }

    public void Shrink()
    {
        if(rectTransform)
        {
            rectTransform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
