using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving : MonoBehaviour
{
    // ��������� ����� ����������
    public Transform goal;
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.destination = goal.position;
    }
}