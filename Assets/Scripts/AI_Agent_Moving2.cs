using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving2 : MonoBehaviour
{
    // Положение точки назначения
    public Transform[] goals;

    public float agentTimerWait = 4;
    public bool IsFinished = false;
    public NavMeshAgent agent;

    public void StartAgent()
    {
        agent.destination = goals[Random.Range(0, goals.Length)].position;
        StartCoroutine(GetGoalForAgent());
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

    IEnumerator GetGoalForAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        yield return new WaitForSeconds(Random.Range(1,4));
        agent.destination = goals[Random.Range(0, goals.Length)].position;
        StartCoroutine(GetGoalForAgent());
    }
}