using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleWarning : MonoBehaviour
{
    bool on = false;
    float currentTime;
    float timeToShow;
    
    // Update is called once per frame
    void Update()
    {
        if (on && currentTime < timeToShow)
        {
            currentTime = Utils.UpdateEnergyCapped(currentTime, timeToShow, 1f);
            if (currentTime == timeToShow) 
            {
                on = false;
                this.GetComponent<Text>().enabled = false;
            }
        }
    }

    public void textForTime(string s, float t)
    {
        currentTime = 0f;
        timeToShow = t;
        on = true;
        this.GetComponent<Text>().text = s;
        this.GetComponent<Text>().enabled = true;
    }
}
