using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityThrowSquare : MonoBehaviour
{
    public GameObject projectile;

    // Ability variables
    public float maxEnergy = 1000f;
    public float energyCost = 150f;
    public float energyRegenRate = 50f;
    public float currentEnergy = 1000f;
    public float projectileSpeed = 60f;
    public float projectileAge = 20f;
    
    public float icd = 1f;
    float currenticd = 0f;

    public bool weaponActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (weaponActive && currentEnergy > energyCost && currenticd == icd)
        {
            GameObject square = Instantiate(projectile, transform) as GameObject;
            square.GetComponent<ThrowSquare>().maxAge = projectileAge;
            Rigidbody rb = square.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            currentEnergy -= energyCost;
            currenticd = 0f;
        }

        currentEnergy = Utils.UpdateEnergyCapped(currentEnergy,  maxEnergy, energyRegenRate);
        currenticd = Utils.UpdateEnergyCapped(currenticd, icd, 1f);
    }
}
