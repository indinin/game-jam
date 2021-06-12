using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    void Update()
    {
        if(!this.gameObject.activeSelf && !isShrunkAndInactive)
        {
            Shrink();
            isShrunkAndInactive = true;
        }

        if(this.gameObject.activeSelf && isShrunkAndInactive)
        {
            isShrunkAndInactive = false;
        }
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
