using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTriggerAreas : MonoBehaviour
{
    public GameObject god;
    public int state;

    void Start()
    {
        god = GameObject.Find("God");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "player")
        {
            god.GetComponent<FSM>().updateState(this.gameObject, state);
        }
    }
}
