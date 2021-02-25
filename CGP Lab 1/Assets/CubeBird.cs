using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBird : MonoBehaviour
{
    public CubeFlockManager manager;
    float speed;
    bool turning = false;
    LayerMask layer = 9;
    public bool playerInSight = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInSight)
        {
            moveAround();
        } 
        else 
        {
            aimAndKill();
        }
    }

    void moveAround()
    {
        Bounds b = manager.boundLimits;
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        if (!b.Contains(transform.position))
        {
            turning = true;
            direction = manager.transform.position - transform.position;
        }
        else if (Physics.Raycast(transform.position, this.transform.forward * 3, out hit, layer))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                //Debug.DrawRay(this.transform.position, this.transform.forward * 3, Color.red);
                turning = true;
                direction = Vector3.Reflect(this.transform.forward, hit.normal);
            }
            else
            {
                turning = false;
            }
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                            Quaternion.LookRotation(direction),
                                            manager.rotationSpeed * Time.deltaTime);
        }
        else 
        {
            if (Random.Range(0, 100) < 5)
            {
                speed = Random.Range(manager.minSpeed, manager.maxSpeed);
            }
            if (Random.Range(0, 100) < 20)
            {
                ApplyRules();
            }
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        List<GameObject> gos;
        gos = manager.allSqrs;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        gos.ForEach(delegate(GameObject go)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (nDistance <= manager.neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (nDistance < manager.avoidDistance)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    CubeBird anotherSqr = go.GetComponent<CubeBird>();
                    gSpeed = gSpeed + anotherSqr.speed;
                }
            }
        }
        );
        if (groupSize > 0)
        {
            vcentre = vcentre/groupSize + (manager.goalPos - this.transform.position);
            //Debug.Log(manager.goalPos);
            speed = gSpeed/groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      manager.rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void aimAndKill()
    {
        this.transform.LookAt(player.transform.position);
        this.transform.GetChild(0).GetComponent<AbilityThrowSquare>().weaponActive = true;
    }

    public void destroy()
    {
        manager.killBird(this.gameObject);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInSight = true;
            player = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInSight = false;
            this.transform.GetChild(0).GetComponent<AbilityThrowSquare>().weaponActive = false;
        }
    }
}
