using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float hp = 20f;
    public float currhp;
    public float defense = 100f; // higher the better, gives a 100/defense multipler to damage taken
    public float playerDetectionRadius = 25f;
    public GameObject pc;

    void checkAlive()
    {
        if (currhp < 0f)
        {
            pc.GetComponent<PlayerCombatStuff>().award(hp);
            if (this.gameObject.name == "CubeBird(Clone)")
            {
                this.GetComponent<CubeBird>().destroy();
            } else if (this.gameObject.name.Contains("Pylon"))
            {
                this.GetComponent<PylonScript>().destroy();
            } else if (this.gameObject.name == "MainCube")
            {
                this.GetComponent<MainCubeScript>().destroy();
            } else
            {
                Destroy(gameObject);
            }
        }
    }

    public void takeDamage(float attack)
    {
        currhp -=  attack * 100/defense;
        checkAlive();
    }

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("player");
        currhp = hp;
        this.tag = "Enemy";
        this.gameObject.layer = 9; //Enemies
        if (this.gameObject.name == "CubeBird(Clone)")
        {
            this.GetComponent<SphereCollider>().radius = playerDetectionRadius;
        }
    }
}
