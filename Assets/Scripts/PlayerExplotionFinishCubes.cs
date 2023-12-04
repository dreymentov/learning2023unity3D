using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplotionFinishCubes : MonoBehaviour
{
    public float power;
    public float radius;
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
        if(collision.gameObject.CompareTag("FinishCube"))
        {
            ExplotionFinishCubes();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinishCube"))
        {
            ExplotionFinishCubes();
        }
    }

    public void ExplotionFinishCubes()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && hit.gameObject.CompareTag("FinishCube"))
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}
