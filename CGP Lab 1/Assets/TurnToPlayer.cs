using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour
{
    public GameObject pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(pc.transform.position);
    }
}
