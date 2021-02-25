using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{
    public Slider slider;

    public void SetCharge(float charge)
    {
        slider.value = charge;
    }

    public void SetMaxCharge(float maxCharge)
    {
        slider.maxValue = maxCharge;
    }
}
