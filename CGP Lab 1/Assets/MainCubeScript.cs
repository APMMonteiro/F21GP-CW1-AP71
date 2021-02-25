using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCubeScript : MonoBehaviour
{
    public bool isActive = false;
    public BossHPBar HPBar;

    // Moving stuff
    public float speed = 0.5f;
    float phase = 0f;
    float phaseDir = 0.5f;
    Vector3 zeros = Vector3.zero;
    public Vector3 endp = new Vector3(0, 2f, 0);
    Vector3 displace;
    Vector3 lastDisplace = Vector3.zero;
    Vector3 amount;
    Vector3 home;
    public float rotationSpeed = 22.5f; //degrees
    
    void Start()
    {
        HPBar.SetMaxHP(gameObject.GetComponent<BasicEnemy>().hp);
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            // vertical
            displace = Vector3.Lerp(zeros, endp, phase);
            phase += speed * phaseDir * Time.deltaTime;
            amount = displace - lastDisplace;
            transform.position += amount;
            lastDisplace = displace;
            if (phase >= 1 || phase <= 0)
            {
                phaseDir *= -1;
            }
            // Rotation
            transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);
            HPBar.SetHP(gameObject.GetComponent<BasicEnemy>().currhp);
        }
    }

    public void destroy()
    {
        transform.parent.GetComponent<BossScript>().finish();
        Destroy(this.gameObject);
    }

    public void turnOnAllGuns()
    {
        for (int i = 0; i < 2; i++)
        {
            Transform child = transform.GetChild(i);
            for (int j = 0; j < child.childCount; j++)
            {
                Transform gun = child.GetChild(j);
                gun.GetComponent<AbilityThrowSquare>().weaponActive = true;
            }
        }
    }
}
