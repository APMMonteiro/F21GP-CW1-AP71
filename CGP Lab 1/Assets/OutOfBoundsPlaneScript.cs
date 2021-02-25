using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsPlaneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "player")
        {
            //Debug.Log("Player out of bounds");
            other.gameObject.GetComponent<PlayerCombatStuff>().KillPlayer();
            //Destroy(other.gameObject);
        }
    }
}
