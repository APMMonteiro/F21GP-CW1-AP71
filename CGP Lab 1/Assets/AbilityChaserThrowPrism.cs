using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChaserThrowPrism : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 40f;

    // Ability variables
    public float maxEnergy = 100f;
    public float energyCost = 50f;
    public float energyRegenRate = 200f;
    public float currentEnergy = 100f;
    
    public float icd = 0.5f;
    float currenticd = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<ChaserScript>().isActive && currentEnergy > energyCost && currenticd == icd)
        {
            GameObject square = Instantiate(projectile, transform) as GameObject;
            Rigidbody rb = square.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            currentEnergy -= energyCost;
            currenticd = 0f;
        }

        currentEnergy = Utils.UpdateEnergyCapped(currentEnergy,  maxEnergy, energyRegenRate);
        currenticd = Utils.UpdateEnergyCapped(currenticd, icd, 1f);
    }
}
