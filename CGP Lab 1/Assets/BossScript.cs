using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int phase = 0;
    public int numPylons = 3;

    public GameObject PylonDefensePrefab;
    public MiddleWarning middleWarning;

    public GameObject pc;

    // Vars to raise pillars
    public bool raisingPillars = false;
    public GameObject pillars;
    public float speed = 0.3f;
    float phaseP = 0f;
    Vector3 zeros = Vector3.zero;
    public Vector3 endp = new Vector3(0, 38f, 0);
    Vector3 displace;
    Vector3 lastDisplace = Vector3.zero;
    Vector3 amount;

    // The Boss Clusters
    public GameObject cluster1;
    public GameObject cluster2;
    //public GameObject cluster3;
    List<GameObject> cluster1sqrs;
    List<GameObject> cluster2sqrs;
    //List<GameObject> cluster3sqrs;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                break;
            case 1:
                executePhase1();
                break;
            case 2:
                if (raisingPillars)
                {
                    raisePillars();
                }
                executePhase2();
                break;
            case 3:
                executePhase3();
                break;
            case 4:
                break;
        }
    }

    public void enterPhase1()
    {
        phase = 1;
        transform.Find("Pylon1").GetComponent<PylonScript>().isActive = true;
        transform.Find("Pylon2").GetComponent<PylonScript>().isActive = true;
        transform.Find("Pylon3").GetComponent<PylonScript>().isActive = true;
        transform.Find("MainCube").GetComponent<MainCubeScript>().isActive = true;
    }

    void executePhase1()
    {
        if (numPylons > 0)
        {
            // Phase Continues
        }
        else
        {
            enterPhase2();
        }       
    }

    void enterPhase2()
    {   
        phase = 2;
        raisingPillars = true;
        transform.GetChild(0).GetComponent<MainCubeScript>().rotationSpeed = 45f;
        middleWarning.textForTime("The Cube Boss has lifted the pillars and unleashed the small cubes! \n Kill them all! \n Your charge rate has been doubled!", 3f);
        pc.transform.GetChild(0).GetChild(0).GetComponent<AbilityThrowBall>().energyRegenRate = 400;
        // spawn clusters
        cluster1.GetComponent<CubeFlockManager>().initialise();
        cluster1sqrs = cluster1.GetComponent<CubeFlockManager>().allSqrs;
        cluster1.transform.GetChild(1).GetComponent<PylonDefenseChaser>().isActive = true;
        cluster2.GetComponent<CubeFlockManager>().initialise();
        cluster2sqrs = cluster2.GetComponent<CubeFlockManager>().allSqrs;
        cluster2.transform.GetChild(1).GetComponent<PylonDefenseChaser>().isActive = true;
    }

    void executePhase2()
    {
        // Until most bird squares are defeated
        if (cluster1sqrs.Count > 3 && cluster2sqrs.Count > 3)
        {
            // Phase Continues
        }
        else
        {
            enterPhase3();
        }
    }

    void enterPhase3()
    {
        phase = 3;
        middleWarning.textForTime("The Cube Boss is enraged and vulnerabe! \n Strike him now!", 3f);
        transform.GetChild(0).GetComponent<MainCubeScript>().rotationSpeed = 180f;
        transform.GetChild(0).GetComponent<MainCubeScript>().endp = new Vector3(0, 8f, 0);
        transform.GetChild(0).GetComponent<BasicEnemy>().defense = 10f;
        transform.GetChild(0).GetComponent<MainCubeScript>().turnOnAllGuns();
    }

    void executePhase3()
    {
        // Shoot
    }

    void raisePillars()
    {
        displace = Vector3.Lerp(zeros, endp, phaseP);
        phaseP += speed * Time.deltaTime;
        amount = displace - lastDisplace;
        pillars.transform.position += amount;
        lastDisplace = displace;
    }

    public void destroyPylon(Vector3 pos)
    {
        numPylons--;
        Vector3 offset = new Vector3(0f, -2f, 0f);
        GameObject go = (GameObject) Instantiate(PylonDefensePrefab, pos + offset, Quaternion.identity);
        go.transform.parent = this.transform;
    }

    public void finish()
    {
        phase = 4;
        middleWarning.textForTime("YOU WON! \n Thanks for playing.", 10000f);
        pc.GetComponent<PlayerCombatStuff>().defense = 10000;
    }
}
