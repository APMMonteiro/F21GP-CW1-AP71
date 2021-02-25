using UnityEngine;
using UnityEngine.AI;

public class ChaserScript : MonoBehaviour
{
    public bool isActive = false;
    public NavMeshAgent agent;
    public CharacterController pc;

    // Update is called once per frame
    void Update()
    {
        if (isActive){
            this.transform.LookAt(pc.transform.position - new Vector3(0, 2f, 0));
            agent.SetDestination(pc.transform.position);
        }
    }
}
