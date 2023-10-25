using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    public void StartAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.destination = goal.position;
    }

    public void Start()
    {
        Invoke("StartAgent", 0.5f);
    }
}