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
    public int j = 0;

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
        j = Random.Range(0, 100);
        for (int i = 0; i < BodyParts.Length; i++)
        {
            
            if (j > 20)
            {
                if (i == n)
                {
                    BodyParts[i].SetActive(true);
                }
            }
            else
            {
                return;
            }
        }

        n = Random.Range(0, Eyes.Length);
        j = Random.Range(0, 100);
        for (int i = 0; i < Eyes.Length; i++)
        {
            if (j > 20)
            {
                if (i == n)
                {
                    Eyes[i].SetActive(true);
                }
            }
            else
            {
                return;
            }
        }

        n = Random.Range(0, MouthandNoses.Length);
        j = Random.Range(0, 100);
        for (int i = 0; i < MouthandNoses.Length; i++)
        {
            if (j > 20)
            {
                if (i == n)
                {
                    MouthandNoses[i].SetActive(true);
                }
            }
            else
            {
                return;
            }
        }

        n = Random.Range(0, HeadParts.Length);
        j = Random.Range(0, 100);
        for (int i = 0; i < HeadParts.Length; i++)
        {
            if (j > 20)
            {
                if (i == n)
                {
                    HeadParts[i].SetActive(true);
                }
            }
            else
            {
                return;
            }
        }

        n = Random.Range(0, Gloves.Length);
        j = Random.Range(0, 100);
        for (int i = 0; i < Gloves.Length; i++)
        {
            if (j > 20)
            {
                if (i == n)
                {
                    Gloves[i].SetActive(true);
                }
            }
            else
            {
                return;
            }
        }

        n = Random.Range(0, Tails.Length);
        /*for (int i = 0; i < Tails.Length; i++)
        {
            if (i == n)
            {
                Tails[i].SetActive(true);
            }
        }*/
        if(Bodies[0].active == true)
        {
            int i = Random.Range(0, 100);
            if(i > 80)
            {
                Tails[0].SetActive(true);
            }
            else if(i > 20 && i < 80)
            {
                Tails[1].SetActive(true);
            }
            else
            {
                return;
            }
        }
        else if (Bodies[1].active == true)
        {
            int i = Random.Range(0, 100);
            if (i > 30)
            {
                Tails[3].SetActive(true);
            }
            else
            {
                return;
            }
        }
        if (Bodies[2].active == true)
        {
            int i = Random.Range(0, 100);
            if (i > 50)
            {
                Tails[2].SetActive(true);
            }
            else if (i > 20 && i < 50)
            {
                Tails[7].SetActive(true);
            }
            else
            {
                return;
            }
        }
        else if (Bodies[3].active == true)
        {
            int i = Random.Range(0, 100);
            if (i > 30)
            {
                Tails[4].SetActive(true);
            }
            else
            {
                return;
            }
        }
        else if (Bodies[4].active == true)
        {
            int i = Random.Range(0, 100);
            if (i > 30)
            {
                Tails[6].SetActive(true);
            }
            else
            {
                return;
            }
        }
        else if (Bodies[5].active == true)
        {
            int i = Random.Range(0, 100);
            if (i > 30)
            {
                Tails[5].SetActive(true);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
