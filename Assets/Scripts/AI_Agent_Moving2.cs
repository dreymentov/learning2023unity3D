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
    public Animator animator;
    public Rigidbody rb;

    public float timeUpdating;
    public Vector3 oldPos;
    public void StartAgent()
    {
        agent.destination = goals[Random.Range(0, goals.Length)].position;
        StartCoroutine(GetGoalForAgent());
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        IsFinished = false;
        Invoke("StartAgent", agentTimerWait);
    }

    public void Update()
    {
        if((this.gameObject.tag != "Bot") && IsFinished == false)
        {
            IsFinished = true;

        }

        if (transform.position == oldPos)
        {
            animator.SetBool("Started", false);
        }
        else animator.SetBool("Started", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            agent.updatePosition = true;
            agent.updateUpAxis = true;
            agent.isStopped = false;
        }
    }


    IEnumerator GetGoalForAgent()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        yield return new WaitForSeconds(Random.Range(1,4));
        agent.destination = goals[Random.Range(0, goals.Length)].position;
        StartCoroutine(GetGoalForAgent());
    }

    public void FixedUpdate()
    {
        timeUpdating += Time.fixedDeltaTime;
        if (timeUpdating > 0.2f)
        {
            timeUpdating = 0;
            oldPos = transform.position;
        }
    }
}