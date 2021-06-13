using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webUI : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void changeValue(float value) 
    {
        slider.value = value;
    }
}
