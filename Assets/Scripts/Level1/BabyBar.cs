using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyBar : MonoBehaviour
{
    public Slider babySlider;
    
    public void IncreasingBabySlider(int fill)
    {
        babySlider.value += fill;
    }

    public void DecreasingBabySlider(int fill)
    {
        babySlider.value -= fill;
    }
}
