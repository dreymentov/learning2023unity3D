using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using CMF;
using UnityEngine.InputSystem.HID;

public class Level3DoorStartLevel : MonoBehaviour
{
    public bool IsDoor;
    public Vector3 NativePos;
    public GameObject[] cubesToCrash;
    // Start is called before the first frame update
    void Awake()
    {
        NativePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        foreach (var cub in cubesToCrash)
        {
            cub.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot") || other.gameObject.CompareTag("Player"))
        {
            if (IsDoor == true)
            {
                Vector3 explosionPos = transform.position;
                gameObject.transform.DOMoveY(-30f, 0f);
                foreach (var cub in cubesToCrash)
                {
                    cub.SetActive(true);
                    cub.transform.parent = null;
                }
                /*foreach (var cub in cubesToCrash)
                {
                    Rigidbody rb = cub.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(100, -explosionPos, 50, 3.0F);
                }*/
            }
            else if (IsDoor == false)
            {
                StartCoroutine(BotLookingAtClosedDoor());
            }
        }
    }

    IEnumerator BotLookingAtClosedDoor()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.AddComponent<NavMeshObstacle>();
        this.gameObject.GetComponent<NavMeshObstacle>().carving = true;
        this.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
        yield return null;
    }
}
