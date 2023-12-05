using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel4Control : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            Vector3 currentVelocity = rb.velocity;
            Vector3 targetVelocity = Vector3.back * 20f;
            targetVelocity = transform.TransformDirection(targetVelocity);
            Vector3 velocityChange = (targetVelocity - currentVelocity);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            Vector3 currentVelocity = rb.velocity;
            Vector3 targetVelocity = Vector3.back * 20f;
            targetVelocity = transform.TransformDirection(targetVelocity);
            Vector3 velocityChange = (targetVelocity - currentVelocity);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}
