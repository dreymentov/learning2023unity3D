using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;
public class AI_Agent_MovingLevel5 : MonoBehaviour
{
    // Положение точки назначения
    public Transform[] goals;
    public float agentTimerWait = 4;
    public bool isChangedFromUntagged = false;
    public Animator animator;
    public Rigidbody rb;
    public NavMeshAgent agent;

    public float JumpForce;
    public float KickForce;

    public bool IsGrounded;
    public bool Jumped;
    public bool WaitedKicked;

    public float timeUpdating;
    public Vector3 oldPos;


    public void StartAgent()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isChangedFromUntagged = false;
        WaitedKicked = false;
        Invoke("StartAgent", agentTimerWait);
    }

    public void Update()
    {
        if((this.gameObject.tag == "Untagged") && (isChangedFromUntagged == false))
        {
            isChangedFromUntagged = true;
            StartCoroutine(VictoryDance());
        }

        

        if (transform.position == oldPos)
        {
            animator.SetBool("Started", false);
        }
        else animator.SetBool("Started", true);
    }

    public void FixedUpdate()
    {
        timeUpdating += Time.fixedDeltaTime;
        if(timeUpdating > 0.2f)
        {
            timeUpdating = 0;
            oldPos = transform.position;
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