using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonScript : MonoBehaviour
{
    public bool isActive = false;

    // Moving stuff
    public float speed = 1f;
    float phase = 0f;
    float phaseDir = 0.5f;
    Vector3 zeros = Vector3.zero;
    public Vector3 endp = new Vector3(0, 1f, 0);
    Vector3 displace;
    Vector3 lastDisplace = Vector3.zero;
    Vector3 amount;
    Vector3 home;
    public float rotationSpeed = 45f; //degrees

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
            
        }
    }

    public void destroy()
    {
        transform.parent.GetComponent<BossScript>().destroyPylon(transform.position);
        Destroy(this.gameObject);
    }
}
