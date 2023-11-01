using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Level3DoorStartLevel : MonoBehaviour
{
    public bool IsDoor;
    public Vector3 NativePos;
    // Start is called before the first frame update
    void Awake()
    {
        NativePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot") || other.gameObject.CompareTag("Player"))
        {
            if (IsDoor == true)
            {
                this.gameObject.transform.DOMoveY(-30f, 0f);
            }
            else if (IsDoor == false)
            {
                this.gameObject.AddComponent<NavMeshObstacle>();
                this.gameObject.GetComponent<NavMeshObstacle>().carving = true;
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
            }
        }
    }
}
