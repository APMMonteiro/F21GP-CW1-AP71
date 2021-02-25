using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBossBirdGoalUpdater : MonoBehaviour
{
    public CubeFlockManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = this.transform.parent.parent.GetComponent<CubeFlockManager>();
    }

    // Update is called once per frame
    void Update()
    {
        manager.goalPos = this.transform.position;
    }
}
