using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBarBackNForth : MonoBehaviour
{
    //Vector3 startpos;
    //Vector3 endpos;
    public float speed = 1f;
    float phase = 0f;
    float phaseDir = 1f;
    Vector3 zeros = new Vector3(0, 0, 0);
    public Vector3 endp = new Vector3(0, 0, 18f);
    Vector3 displace;
    Vector3 lastDisplace = new Vector3(0, 0, 0);
    Vector3 amount;

    public bool isActive = false;
    public bool isInContactWithPlayer = false;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        //startpos = transform.position;
        //endpos = transform.position + displace;
    }

    // Update is called once per frame
    void Update()
    {   
        if (isActive)
        {
            displace = Vector3.Lerp(zeros, endp, phase);
            phase += speed * phaseDir * Time.deltaTime;
            amount = displace - lastDisplace;
            transform.position += amount;
            
            if (isInContactWithPlayer)
            {
                controller.Move(amount);

            }
            lastDisplace = displace;
            if (phase >= 1 || phase <= 0)
            {
                phaseDir *= -1;
            }
        }
        
        isInContactWithPlayer = false;
    }

    public void playerHit()
    {
        isInContactWithPlayer = true;
    }
}
