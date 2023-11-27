using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShop : MonoBehaviour
{
    public Animator animator;
    public bool needAnim;

    // Start is called before the first frame update
    void Start()
    {
        if (needAnim == true)
        {
            animator.SetInteger("VictoryDance", -1);
        }
        else
        {
            animator = GetComponent<Animator>();
            Destroy(animator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
