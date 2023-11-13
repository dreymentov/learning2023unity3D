using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving2 : MonoBehaviour
{
    // Положение точки назначения
    public Transform[] goals;
    public float agentTimerWait = 4;
    public bool IsFinished = false;

    public void StartAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goals[Random.Range(0, goals.Length - 1)].position;
    }

    public void Start()
    {
        IsFinished = false;
        Invoke("StartAgent", agentTimerWait);
    }

    public void Update()
    {
        if((this.gameObject.tag != "Bot") && IsFinished == false)
        {
            IsFinished = true;

        }
    }
}