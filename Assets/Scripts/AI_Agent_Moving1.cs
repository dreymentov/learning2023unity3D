using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class AI_Agent_Moving1 : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;

    public Rigidbody rb;

    public Level1Managment level1mg;

    public NavMeshAgent agent;

    public int cubesCountOld;
    public int changeValue;
    public int changeValueJump;

    public float jumpPower;
    public float jumpPowerForward;

    public float agentTimerWait = 4;

    public bool isGrounded;
    public bool needJumping;
    public bool isStartGame;
    public bool wasJump;

    public bool isChangedFromUntagged = false;
    public Animator animator;

    public void Start()
    {
        if(level1mg != null)
        {
            AI_Agent_Moving1 agentMove1 = this.GetComponent<AI_Agent_Moving1>();
            Destroy(agentMove1);
        }
        animator = GetComponent<Animator>();
        isChangedFromUntagged = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        cubesCountOld = level1mg.cubes.Count;
        isStartGame = false;
        wasJump = false;
        Invoke("OnAwakeAgent", agentTimerWait);
    }

    public void OnAwakeAgent()
    {
        if (level1mg != null)
        {
            AI_Agent_Moving1 agentMove1 = this.GetComponent<AI_Agent_Moving1>();
            Destroy(agentMove1);
        }
        agent = GetComponent<NavMeshAgent>();
        goal = level1mg.cubes[Random.Range(0, level1mg.cubes.Count)].transform;
        agent.destination = goal.position;
        isStartGame = true;
    }

    public void FixedUpdate()
    {
        if(isStartGame) 
        {
            if (needJumping)
            {
                if (isGrounded)
                {
                    StartCoroutine(Jump());
                }
            }

            if (isGrounded && wasJump)
            {
                if (agent.enabled == false)
                {
                    wasJump = false;
                    agent.enabled = true;

                    Invoke("GetOrChangeGoal", 0f);
                }
                else
                {
                    wasJump = false;
                }
            }

            if (cubesCountOld != level1mg.cubes.Count)
            {
                cubesCountOld = level1mg.cubes.Count;

                Invoke("GetOrChangeGoal", 0f);
            }
            else
            {
                changeValue = Random.Range(0, 101);
                if (changeValue > 70)
                {
                    Invoke("GetOrChangeGoal", 0f);
                }
            }
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("Obstacle"))
        {
            needJumping = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        if (other.CompareTag("Obstacle"))
        {
            needJumping = false;
        }
    }

    public void Update()
    {
        if ((this.gameObject.tag == "Untagged") && (isChangedFromUntagged == false))
        {
            isChangedFromUntagged = true;
            StartCoroutine(VictoryDance());
        }
    }

    IEnumerator Jump()
    {
        changeValueJump = Random.Range(0, 101);
        if (changeValueJump > 85)
        {
            StartCoroutine(NoJumped());
        }
        else if (changeValueJump <= 85 && changeValueJump > 70)
        {
            StartCoroutine(JumpedTooLate());
        }
        else
        {
            StartCoroutine(Jumped());
        }
        yield break;
    }

    IEnumerator Jumped()
    {
        if (agent.enabled == true)
        {
            agent.enabled = false;
        }
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * jumpPowerForward);

        yield return new WaitForSeconds(1f);
        wasJump = true;
    }

    IEnumerator JumpedTooLate()
    {
        if (agent.enabled == true)
        {
            agent.enabled = false;
        }
        yield return new WaitForSeconds(1.5f);

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * jumpPowerForward);

        yield return new WaitForSeconds(1f);
        wasJump = true;
    }

    IEnumerator NoJumped()
    {
        if (agent.enabled == true)
        {
            agent.enabled = false;
        }
        yield return new WaitForSeconds(1.5f);

        rb.isKinematic = false;
        rb.useGravity = true;

        yield return new WaitForSeconds(1f);
        if (agent.enabled == false)
        {
            agent.enabled = true;
        }
    }

    public void GetOrChangeGoal()
    {
        goal = level1mg.cubes[Random.Range(0, level1mg.cubes.Count)].transform;

        if (agent.enabled == true)
        {
            agent.destination = goal.position;
        }
        else
            return;
    }

    IEnumerator VictoryDance()
    {
        animator.SetBool("IsFinished", true);
        //animator.SetFloat("VictoryDance", (int)Random.Range(0, 3));
        yield return new WaitForSeconds(2f);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return null;
    }
}