using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor5Lift : MonoBehaviour
{
    public float speed = 1f;
    float phase = 0f;
    float phaseDir = 0.5f;
    Vector3 zeros = Vector3.zero;
    public Vector3 endp = new Vector3(0, 24f, 0);
    Vector3 displace;
    Vector3 lastDisplace = Vector3.zero;
    Vector3 amount;
    Vector3 home;

    public bool isActive = false;
    public bool isInContactWithPlayer = false;
    public CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if (isActive)
        {
            phaseDir = 1f;
            displace = Vector3.Lerp(zeros, endp, phase);
            phase += speed * phaseDir * Time.deltaTime;
            amount = displace - lastDisplace;
            transform.position += amount;
            
            if (isInContactWithPlayer)
            {
                controller.Move(amount);

            }
            lastDisplace = displace;
        }
        else
        {
            if (transform.position != home)
            {
                phaseDir = -1f;
                displace = Vector3.Lerp(zeros, endp, phase);
                phase += speed * phaseDir * Time.deltaTime;
                amount = displace - lastDisplace;
                transform.position += amount;
                lastDisplace = displace;
            }
        }
        
        isInContactWithPlayer = false;
    }

    public void playerHit()
    {
        isInContactWithPlayer = true;
    }
}
