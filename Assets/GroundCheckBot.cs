using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckBot : MonoBehaviour
{   
    public AI_Agent_Moving1 AIL1;
    public AI_Agent_Moving AIL2;
    public AI_Agent_Moving2 AIL3;
    public AI_Agent_MovingLevel4 AIL4;
    public AI_Agent_MovingLevel5 AIL5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if(AIL1 != null)
            {
                AIL1.SetGrounded(true);
            }
            else if(AIL2 != null)
            {
                
            }
            else if(AIL3 != null)
            {
                
            }
            else if(AIL4 != null)
            {
                AIL4.SetGrounded(true);
            }
            else if(AIL5 != null)
            {

            }
            else 
            {
                Debug.LogError("No AI level 5+ component");
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (AIL1 != null)
            {
                AIL1.SetGrounded(true);
            }
            else if (AIL2 != null)
            {

            }
            else if (AIL3 != null)
            {

            }
            else if (AIL4 != null)
            {
                AIL4.SetGrounded(true);
            }
            else if (AIL5 != null)
            {

            }
            else
            {
                //Debug.LogError("No AI level 5+ component");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (AIL1 != null)
            {
                AIL1.SetGrounded(false);
            }
            else if (AIL2 != null)
            {

            }
            else if (AIL3 != null)
            {

            }
            else if (AIL4 != null)
            {
                AIL4.SetGrounded(false);
            }
            else if (AIL5 != null)
            {

            }
            else
            {
                Debug.LogError("No AI level 5+ component");
            }
        }
    }
}
