using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSquare : MonoBehaviour
{
    float currentCharge = 25f;
    public float chargeRate = 50f;
    public float maxCharge = 100f;

    float currentAge = 0f;
    public float maxAge = 10f;
    public float ageRate = 1f;

    public float baseDamage = 5f;
    public float numCollisions = 0f;

    // Start is called before the first frame update
    void Start()
    {
        float scale = currentCharge/maxCharge;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentCharge = Utils.UpdateEnergyCapped(currentCharge, maxCharge, chargeRate);
        currentAge = Utils.UpdateEnergyCapped(currentAge, maxAge, ageRate);

        float scale = currentCharge/maxCharge;
        transform.localScale = new Vector3(scale, scale, scale);

        if (currentAge >= maxAge) 
        {
            Destroy(gameObject);
        }
    }

    private float calculateDamage()
    {
        return baseDamage * currentCharge/maxCharge * Mathf.Pow(2f,(Mathf.Min(numCollisions, 3f)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collided with object of layer: " + collision.gameObject.layer);
        if (collision.gameObject.layer == 8) //Ground
        {
            numCollisions++;
        }
        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerCombatStuff>().takeDamage(calculateDamage());
            Destroy(gameObject);
        }
    }
}