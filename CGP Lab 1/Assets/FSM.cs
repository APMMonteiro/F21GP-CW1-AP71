using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public FloorNumUI floorNumUI;
    public MiddleWarning middleWarning;
    public InfoText infoText;
    public GameObject pc;
    public GameObject bossHPBar;

    public int floor = 1; // Each floor is a state

    // Start is called before the first frame update
    void Start()
    {
        floorNumUI.updateFloor(floor);
        infoText.textUntilClickWithMinTimer("You've crashed into this prismatic tower \n you're a ball, you hate the cubes and the other prisms \n kill them. \n Left click to close this message", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateState(GameObject go, int i)
    {
        floorNumUI.updateFloor(i);
        pc.GetComponent<PlayerMovementScript>().updateState(i);
        if (i > floor)
        {
            floor = i;
            switch (i)
            {
                case 3:
                    middleWarning.textForTime("You reached floor " + i, 3f);
                    infoText.textUntilClickWithMinTimer("These moving platforms might push you off, beware.", 2f);
                    break;
                case 5:
                    middleWarning.textForTime("You reached floor " + i, 3f);
                    infoText.textUntilClickWithMinTimer("Cube swarms, more bothersome than dangerous \n they patrol an area but will attack you if you get too close.", 2f);
                    GameObject.Find("CubeClusterManager").GetComponent<CubeFlockManager>().initialise();
                    break;
                case 6:
                    middleWarning.textForTime("You reached floor " + i, 3f);
                    infoText.textUntilClickWithMinTimer("A Chaser Prism, theyre quite deadly \n run!",2f);
                    GameObject.Find("ChaserPrism").GetComponent<ChaserScript>().isActive = true;
                    break;
                case 7:
                    middleWarning.textForTime("You reached floor " + i, 3f);
                    infoText.textUntilClickWithMinTimer("It's a boss Cube! \n You must destroy it. \n The pylons on the corners first!", 2f);
                    GameObject.Find("Boss").GetComponent<BossScript>().enterPhase1();
                    bossHPBar.SetActive(true);
                    break;
                case 8:
                    infoText.textUntilClickWithMinTimer("You won!", 10000f);
                    bossHPBar.SetActive(false);
                    break;
            }
        }
    }


}
