using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving2 : MonoBehaviour
{
    // Положение точки назначения
    public Transform[] goals;
    public void StartAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[Random.Range(0, goals.Length - 1)].position;
    }

    public void Start()
    {
        Invoke("StartAgent", 0.5f);
    }
}