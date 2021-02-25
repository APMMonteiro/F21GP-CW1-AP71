using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public void updateScore(float f)
    {
        this.GetComponent<Text>().text = "Score: " + f;
    }
}
