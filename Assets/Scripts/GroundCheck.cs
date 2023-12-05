using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerControlls playerControlls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerControlls.gameObject)
        {
            return;
        }

        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Jump"))
        {
            playerControlls.SetGrounded(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerControlls.gameObject)
        {
            return;
        }

        playerControlls.SetGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerControlls.gameObject)
        {
            return;
        }

        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Jump"))
        {
            playerControlls.SetGrounded(true);
        }
    }
}
