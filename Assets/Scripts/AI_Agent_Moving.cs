using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    public float agentTimerWait = 4;
    public bool isChangedFromUntagged = false;
    public Animator animator;
    public Rigidbody rb;
    public NavMeshAgent agent;


    public void StartAgent()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = goal.position;
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isChangedFromUntagged = false;
        Invoke("StartAgent", agentTimerWait);
    }

    public void Update()
    {
        if((this.gameObject.tag == "Untagged") && (isChangedFromUntagged == false))
        {
            isChangedFromUntagged = true;
            StartCoroutine(VictoryDance());
        }

        if ((rb.velocity.x < 0.2f && rb.velocity.x > -0.2f) || (rb.velocity.y < 0.2f && rb.velocity.y > -0.2f))
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

    IEnumerator VictoryDance()
    {
        animator.SetBool("IsFinished", true);
        //animator.SetFloat("VictoryDance", (int)Random.Range(0, 3));
        yield return new WaitForSeconds(2f);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        rb.useGravity = enabled;
        yield return null;
    }
}