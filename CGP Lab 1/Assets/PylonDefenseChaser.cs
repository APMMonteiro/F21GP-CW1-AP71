using UnityEngine;
using UnityEngine.AI;

public class PylonDefenseChaser : MonoBehaviour
{
    public bool isActive = false;
    public NavMeshAgent agent;
    public CharacterController pc;

    void Start()
    {
        pc = GameObject.Find("player").GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isActive){
            agent.SetDestination(pc.transform.position);
        }
    }
}
