using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsctacles : MonoBehaviour
{
    public bool obstacl1;
    public bool obstacl2;
    public bool obstacl3;
    public bool obstacl4;
    public bool obstacl5;
    public bool obstacl6;
    public bool obstacl7;

    public float powerObstacl;

    public Vector3 posObs;
    public Vector3 posPlayer;

    public GameObject FromToTeleportObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obstacl4)
        {
            this.gameObject.transform.Rotate(0, 0, powerObstacl * Time.fixedDeltaTime);
        }

        if (obstacl6)
        {
            this.gameObject.transform.Rotate(0, powerObstacl * Time.fixedDeltaTime, 0);
        }

        if (obstacl7)
        {
            this.gameObject.transform.Rotate(powerObstacl * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (obstacl2)
        {
            if(other.tag == "Player")
            {
                other.gameObject.GetComponent<Rigidbody>().transform.LookAt(this.gameObject.transform);
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward * powerObstacl);
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up + Vector3.up * powerObstacl);
            }
        }

        if (obstacl3)
        {
            if (other.tag == "Player")
            {
                other.gameObject.transform.position = new Vector3(FromToTeleportObject.transform.position.x, FromToTeleportObject.transform.position.y + 3f, FromToTeleportObject.transform.position.z);
                other.gameObject.transform.rotation = Quaternion.Euler(0, FromToTeleportObject.transform.rotation.y, 0);
            }
        }

        if (obstacl5)
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * powerObstacl);
            }
        }
    }
}
