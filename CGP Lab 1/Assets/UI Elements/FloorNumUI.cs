using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorNumUI : MonoBehaviour
{
    public void updateFloor(int n)
    {
        this.GetComponent<Text>().text = "At floor: " + n;
    }
}
