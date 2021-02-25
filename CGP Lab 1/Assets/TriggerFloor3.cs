using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloor3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "player")
        {
            Transform child;
            for (int i = 0; i < transform.childCount; i++)
            {
                child = transform.GetChild(i);
                child.GetComponent<PushBarBackNForth>().isActive = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "player")
        {
            Transform child;
            for (int i = 0; i < transform.childCount; i++)
            {
                child = transform.GetChild(i);
                child.GetComponent<PushBarBackNForth>().isActive = false;
            }
        }
    }
}
