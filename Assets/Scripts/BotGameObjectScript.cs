using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGameObjectScript : MonoBehaviour
{
    public GameObject CubForStart;
    public GameObject[] Bodies;
    public GameObject[] BodyParts;
    public GameObject[] Eyes;
    public GameObject[] Gloves;
    public GameObject[] HeadParts;
    public GameObject[] MouthandNoses;
    public GameObject[] Tails;
    public int n = 0;

    // Start is called before the first frame update
    void Start()
    {
        CubForStart.SetActive(false);

        n = Random.Range(0, Bodies.Length);
        for(int i = 0; i < Bodies.Length; i++)
        {
            if(i == n)
            {
                Bodies[i].SetActive(true);
            }
        }

        n = Random.Range(0, BodyParts.Length);
        for (int i = 0; i < BodyParts.Length; i++)
        {
            if (i == n)
            {
                BodyParts[i].SetActive(true);
            }
        }

        n = Random.Range(0, Eyes.Length);
        for (int i = 0; i < Eyes.Length; i++)
        {
            if (i == n)
            {
                Eyes[i].SetActive(true);
            }
        }

        n = Random.Range(0, MouthandNoses.Length);
        for (int i = 0; i < MouthandNoses.Length; i++)
        {
            if (i == n)
            {
                MouthandNoses[i].SetActive(true);
            }
        }

        n = Random.Range(0, HeadParts.Length);
        for (int i = 0; i < HeadParts.Length; i++)
        {
            if (i == n)
            {
                HeadParts[i].SetActive(true);
            }
        }

        n = Random.Range(0, Gloves.Length);
        for (int i = 0; i < Gloves.Length; i++)
        {
            if (i == n)
            {
                Gloves[i].SetActive(true);
            }
        }

        n = Random.Range(0, Tails.Length);
        for (int i = 0; i < Tails.Length; i++)
        {
            if (i == n)
            {
                Tails[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
