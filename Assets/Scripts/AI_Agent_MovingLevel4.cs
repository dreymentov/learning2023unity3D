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
    public Level4Managment level4;

    public float JumpForce;

    public bool IsGrounded;
    public bool Jumped;

    public bool isTriggerObs;


    public void StartAgent()
    {
        agent.destination = goals[Random.Range(0,goals.Length)].position;
        StartCoroutine(RandomGoal());
    }

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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

        if(isTriggerObs)
        {
            agent.updatePosition = false;
            agent.isStopped = true;
        }

        if ((rb.velocity.x < 0.2f && rb.velocity.x > -0.2f) || (rb.velocity.y < 0.2f && rb.velocity.y > -0.2f))
        {
            animator.SetBool("Started", false);
        }
        else animator.SetBool("Started", true);
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
        yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        agent.destination = goals[Random.Range(0, goals.Length)].position;
        StartCoroutine(RandomGoal());
        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
        }*/

        if (other.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

    IEnumerator JumpAgent()
    {
        agent.updatePosition = false;
        agent.isStopped = true;
        Vector3 jumpForces = Vector3.zero;

        float speedObs = 1 / level4.ifStayedToUpgradeSpeedAgainObstacles;

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
            rb.AddRelativeForce(new Vector3(0, 0, speedObs * 0.025f), ForceMode.VelocityChange);
        }
        else if((i > 15) && (i <= 30))
        {
            yield return new WaitForSeconds(0.2f);
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
            rb.AddRelativeForce(new Vector3(0, 0, speedObs * 0.05f), ForceMode.VelocityChange);
        }
        else
        {
            yield return new WaitForSeconds(0.8f);
            rb.AddForce(jumpForces, ForceMode.VelocityChange);
            rb.AddRelativeForce(new Vector3(0, 0, speedObs * 0.1f), ForceMode.VelocityChange);
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
            agent.updateRotation = false;
            transform.LookAt(collision.transform);
            agent.updateRotation = true;
        }

        if (collision.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
            agent.updatePosition = false;
            agent.isStopped = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            StartCoroutine(JumpAgent());
            agent.updateRotation = false;
            transform.LookAt(collision.transform);
            agent.updateRotation = true;
        }

        if (collision.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = true;
            agent.updatePosition = false;
            agent.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("DisableAgent"))
        {
            isTriggerObs = false;
            agent.updatePosition = true;
            agent.isStopped = false;
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded == false)
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
            rb.AddForce(Vector3.down * 9.81f * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        else
        {
            if (isTriggerObs == false)
            {
                agent.updatePosition = true;
                agent.updateUpAxis = true;
                agent.isStopped = false;
            }
        }
    }
    public void SetGrounded(bool state)
    {
        IsGrounded = state;
    }
}