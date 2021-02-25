using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor6LiftTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            transform.parent.GetComponent<Floor6Lift>().isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            transform.parent.GetComponent<Floor6Lift>().isActive = false;
        }
    }
}
