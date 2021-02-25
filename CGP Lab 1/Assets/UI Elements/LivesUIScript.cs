using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUIScript : MonoBehaviour
{
    public void updateLives(int lives)
    {
        this.GetComponent<Text>().text = "Lives left: " + lives;
    }
}
