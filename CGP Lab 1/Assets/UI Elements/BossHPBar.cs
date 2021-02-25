using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public Slider slider;

    public void SetHP(float value)
    {
        slider.value = value;
    }

    public void SetMaxHP(float maxValue)
    {
        slider.maxValue = maxValue;
    }
}
