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
        /*if(level1mg != null)
        {
            AI_Agent_Moving1 agentMove1 = this.GetComponent<AI_Agent_Moving1>();
            Destroy(agentMove1);
        }*/
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
/*        if (level1mg != null)
        {
            AI_Agent_Moving1 agentMove1 = this.GetComponent<AI_Agent_Moving1>();
            Destroy(agentMove1);
        }*/
        agent = GetComponent<NavMeshAgent>();
        goal = level1mg.cubes[Random.Range(0, level1mg.cubes.Count)].transform;
        agent.destination = goal.position;
        isStartGame = true;
    }

    public void FixedUpdate()
    {
        if (level1mg.isCrashingPlace == true)
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
        }
        else
        {
            if (isStartGame)
            {
                if(isGrounded == false)
                {
                    agent.updatePosition = false;
                    agent.updateUpAxis = false;
                    agent.isStopped = true;
                }
                else
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
                        if (agent.updatePosition == false)
                        {
                            wasJump = false;
                            agent.updatePosition = true;
                            agent.updateUpAxis = true;
                            Invoke("GetOrChangeGoal", 0f);
                        }
                        else
                        {
                            wasJump = false;
                        }
                    }
                    else if (isGrounded)
                    {
                        if (agent.updatePosition == false)
                        {
                            agent.updatePosition = true;
                            agent.updateUpAxis = true;
                        }
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

        if (other.CompareTag("Player"))
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("Obstacle"))
        {
            needJumping = true;
        }

        if (other.CompareTag("Player"))
        {
            agent.updatePosition = false;
            agent.updateUpAxis = false;
            agent.isStopped = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            needJumping = false;
        }

        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

    public void Update()
    {
        if ((this.gameObject.tag == "Untagged") && (isChangedFromUntagged == false))
        {
            isChangedFromUntagged = true;
            StartCoroutine(VictoryDance());
        }

        if(level1mg.isFinishedLevel1 == true)
        {
            this.gameObject.CompareTag("Untagged");
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
        agent.updatePosition = false;
        agent.updateUpAxis = false;
        agent.isStopped = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        rb.AddForce(Vector3.forward * jumpPowerForward);

        yield return new WaitForSeconds(1f);
        wasJump = true;
    }

    IEnumerator JumpedTooLate()
    {
        agent.updatePosition = false;
        agent.updateUpAxis = false;
        agent.isStopped = true;
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
        agent.updatePosition = false;
        yield return new WaitForSeconds(1.5f);

        rb.isKinematic = false;
        rb.useGravity = true;

        yield return new WaitForSeconds(1f);

        if (level1mg.isCrashingPlace == false)
        {
            agent.isStopped = false;
            agent.updatePosition = true;
            agent.updateUpAxis = true;
        }
    }

    public void GetOrChangeGoal()
    {
        goal = level1mg.cubes[Random.Range(0, level1mg.cubes.Count)].transform;

        agent.destination = goal.position;
    }

    IEnumerator VictoryDance()
    {
        animator.SetBool("IsFinished", true);
        //animator.SetFloat("VictoryDance", (int)Random.Range(0, 3));
        yield return new WaitForSeconds(2f);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.isStopped = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        yield return null;
    }

    public void SetGrounded(bool state)
    {
        isGrounded = state;
    }
}