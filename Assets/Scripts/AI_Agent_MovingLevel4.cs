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

    public bool IsGrounded;
    public bool Jumped;

    public bool isTriggerObs;


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
        Invoke("StartAgent", agentTimerWait);
    }

    public void Update()
    {
        if((this.gameObject.tag == "Untagged") && (isChangedFromUntagged == false))
        {
            isChangedFromUntagged = true;
            StartCoroutine(VictoryDance());
        }

        /*if(agent.enabled == false)
        {
            this.transform.LookAt(new Vector3(goals[idGoal].transform.position.x, 0, goals[idGoal].transform.position.z));

            Vector3 currentVelocity = rb.velocity;
            Vector3 targetVelocity = new Vector3(10, 0, 0);
            Vector3 velocityChange = (targetVelocity - currentVelocity);
            targetVelocity = transform.TransformDirection(targetVelocity);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }*/
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
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        if (agent.enabled == true)
        {
            agent.destination = goals[Random.Range(0, goals.Length)].position;
        }
        StartCoroutine(RandomGoal());
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
        }*/

        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;

            if (Jumped == true)
            {
                Jumped = false;
            }
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
             IsGrounded = true;

             if (Jumped == true)
             {
                 Jumped = false;
             }
            else
            {
                if(isTriggerObs == false)
                {
                    agent.updatePosition = true;
                }
            }
        }

        if (other.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }

        /*if(other.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = false;
        }*/
    }

    IEnumerator JumpAgent()
    {
        agent.updatePosition = false;
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
        yield return new WaitForSeconds(0.2f);

        Jumped = true;

        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }

        if (collision.gameObject.CompareTag(""))
        {
            isTriggerObs = true;
            agent.updatePosition = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }

        if (collision.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
            agent.updatePosition = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = false;
            agent.updatePosition = true;
        }
    }
}