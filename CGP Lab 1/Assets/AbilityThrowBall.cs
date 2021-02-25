using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityThrowBall : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 60f;

    // Ability variables
    public float maxEnergy = 1000f;
    public float energyCost = 150f;
    public float energyRegenRate = 100f;
    public float currentEnergy = 500f;
    
    public float icd = 1f;
    float currenticd = 0f;

    public ChargeBar chargeBar; 

    // Start is called before the first frame update
    void Start()
    {
        //chargeBar = GameObject.Find("ChargeBar").GetComponent<Slider>();
        chargeBar.SetMaxCharge(maxEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && currentEnergy > energyCost && currenticd == icd)
        {
            GameObject ball = Instantiate(projectile, transform) as GameObject;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            currentEnergy -= energyCost;
            currenticd = 0f;
        }

        currentEnergy = Utils.UpdateEnergyCapped(currentEnergy,  maxEnergy, energyRegenRate);
        currenticd = Utils.UpdateEnergyCapped(currenticd, icd, 1f);
        chargeBar.SetCharge(currentEnergy);
    }
}
