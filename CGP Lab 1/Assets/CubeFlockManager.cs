using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFlockManager : MonoBehaviour
{
    public GameObject god;
    public bool isActive;
    public bool isBoss;

    public GameObject squarePrefab;
    public int numSqrs = 10;
    public List<GameObject> allSqrs;
    public Vector3 limits = new Vector3(8, 8, 8);
    
    [Header("Sqr Flock Settings")]
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float neighbourDistance = 30f;
    public float rotationSpeed = 3f;
    public float avoidDistance = 1f;
    [Header("Sqr Enemy Settings")]
    public float squareHP = 12f;
    public float squareDefense = 100f;
    public Bounds boundLimits;

    // Movement Stuff
    [Header("Movement Settings")]
    public GameObject goalChild;
    public float speed = 0.1f;
    float phase = 0f;
    float phaseDir = 1f;
    Vector3 zeros = new Vector3(0, 0, 0);
    public Vector3 endp = new Vector3(0, 0, 32f);
    Vector3 displace;
    Vector3 lastDisplace = new Vector3(0, 0, 0);
    Vector3 amount;
    public Vector3 goalPos;


    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.Find("God");
    }

    public void initialise()
    {
        isActive = true;
        boundLimits = this.transform.GetChild(0).GetComponent<Collider>().bounds;
        allSqrs = new List<GameObject>();
        for (int i = 0; i < numSqrs; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-limits.x, limits.x),
                                                                Random.Range(-limits.y, limits.y),
                                                                Random.Range(-limits.z, limits.z));
            allSqrs.Add( (GameObject) Instantiate(squarePrefab, pos, Quaternion.identity) );
            allSqrs[i].GetComponent<CubeBird>().manager = this;
            allSqrs[i].GetComponent<BasicEnemy>().hp = squareHP;
            allSqrs[i].GetComponent<BasicEnemy>().defense = squareDefense;
        }
        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && !isBoss)
        {
            updateGoalPos();
        }
    }

    public void killBird(GameObject bird)
    {
        allSqrs.Remove(bird);
    }

    void updateGoalPos()
    {
        displace = Vector3.Lerp(zeros, endp, phase);
        phase += speed * phaseDir * Time.deltaTime;
        amount = displace - lastDisplace;
        goalChild.transform.position += amount;
        lastDisplace = displace;
        if (phase >= 1 || phase <= 0)
        {
            phaseDir *= -1;
        }
        goalPos = goalChild.transform.position;
    }
}
