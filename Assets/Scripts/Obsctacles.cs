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

    public bool isContactToUpPower;
    public bool hasContact;
    public bool isNegativeSpeed;

    public float powerObstacl;
    public float nativePowerObstacl;

    public Vector3 posObs;
    public Vector3 posPlayer;

    public GameObject FromToTeleportObject;

    // Start is called before the first frame update
    void Start()
    {
        nativePowerObstacl = powerObstacl;

        if (isContactToUpPower == true)
        {
            StartCoroutine(DowngradeSpeedObstacle());
        }
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
        /*if (obstacl2)
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
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Bot") || collision.gameObject.CompareTag("Player")) && isContactToUpPower == true)
        {
            hasContact = true;
            Debug.Log("Contact!");
        }
        else
        {
            Debug.Log("Contact another tag!");
            return;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Bot") || collision.gameObject.CompareTag("Player")) && isContactToUpPower == true)
        {
            Debug.Log("Contact stay!");
            hasContact = true;
        }
        else
        {
            Debug.Log("Contact stay another tag!");
            return;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Bot") || collision.gameObject.CompareTag("Player")) && isContactToUpPower == true)
        {
            Debug.Log("Contact end!");
            hasContact = false; 
        }
        else
        {
            hasContact = false;
            Debug.Log("Contact end another tag!");
            return;
        }
    }

    IEnumerator DowngradeSpeedObstacle()
    {
        if (hasContact == false)
        {
            if(isNegativeSpeed == false)
            {
                if (powerObstacl > nativePowerObstacl)
                {
                    powerObstacl -= 2f;
                }
            }
            else
            {
                if (powerObstacl < nativePowerObstacl)
                {
                    powerObstacl += 2f;
                }
            }
            
        }
        else
        {
            if (isNegativeSpeed == false)
            {
                if (powerObstacl < nativePowerObstacl * 10)
                {
                    powerObstacl += 1f;
                }
            }
            else
            {
                if (powerObstacl > nativePowerObstacl * 10)
                {
                    powerObstacl -= 1f;
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(DowngradeSpeedObstacle());
    }
}
