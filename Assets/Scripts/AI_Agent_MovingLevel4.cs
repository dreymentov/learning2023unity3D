using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using DG.Tweening;
public class AI_Agent_MovingLevel4 : MonoBehaviour
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


    public void StartAgent()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = goals[Random.Range(0,goals.Length)].position;
        StartCoroutine(RandomGoal());
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

        if(agent.enabled == false)
        {
            rb.useGravity = true;
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

    IEnumerator RandomGoal()
    {
        yield return new WaitForSeconds(Random.Range(0, 5));
        if(agent.enabled == true)
        {
            agent.destination = goals[Random.Range(0, goals.Length)].position;
        }
        StartCoroutine(RandomGoal());
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {
            agent.enabled = false;
            StartCoroutine(JumpAgent());
        }

        if(other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;

            if(Jumped == true)
            {
                Jumped = false;
                agent.enabled = true;
                agent.destination = goals[Random.Range(0, goals.Length)].position;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;

            if ((Jumped == true) && (WaitedKicked == false))
            {
                Jumped = false;
                agent.enabled = true;
                agent.destination = goals[Random.Range(0, goals.Length)].position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    IEnumerator JumpAgent()
    {
        Vector3 jumpForces = Vector3.zero;

        if (IsGrounded)
        {
            jumpForces = Vector3.up * JumpForce;
        }
        else 
        {
            ;
        }
        
        int i = Random.Range(0, 100);

        if(i > 30)
        {
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
        }
        else if((i > 15) && (i <= 30))
        {
            yield return new WaitForSeconds(0.2f);
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
        }
        else
        {
            yield return new WaitForSeconds(0.8f);
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
        }
        yield return new WaitForSeconds(1f);

        Jumped = true;

        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Jump"))
        {
            WaitedKicked = true;
            agent.enabled = false;
           /* transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            Vector3 KickPower = Vector3.zero;
            KickPower = -Vector3.back * KickForce;
            rb.AddForce(KickPower, ForceMode.VelocityChange);*/
            Debug.Log(this + " kicked");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Jump"))
        {
            WaitedKicked = true;
            agent.enabled = false;
            /*transform.DORotate(new Vector3(0, 180, 0), 0.2f);
            Vector3 KickPower = Vector3.zero;
            KickPower = -Vector3.back * KickForce;
            rb.AddForce(KickPower, ForceMode.VelocityChange);*/
            Debug.Log(this + " kicked in stay");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Jump"))
        {
            //StartCoroutine(EnableAgentAfterKick());
        }
    }

    IEnumerator EnableAgentAfterKick()
    {
        yield return new WaitForSeconds(1f);
        WaitedKicked = false;
        yield break;
    }
}