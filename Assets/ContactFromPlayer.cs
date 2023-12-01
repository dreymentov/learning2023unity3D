using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactFromPlayer : MonoBehaviour
{
    public float powerKickFromPlayer;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 changingPos = collision.transform.position - transform.position;
            Vector3 changePos = transform.position - (changingPos);
            rb.AddForce(changePos * powerKickFromPlayer, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 changingPos = collision.transform.position - transform.position;
            Vector3 changePos = transform.position - (changingPos);
            rb.AddForce(changePos * powerKickFromPlayer, ForceMode.VelocityChange);
        }
    }
}
