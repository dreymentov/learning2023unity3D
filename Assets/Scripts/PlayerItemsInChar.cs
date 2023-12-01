using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerItemsInChar : MonoBehaviour
{
    public GameObject[] Bodies; 
    public GameObject[] Bodyparts; 
    public GameObject[] Eyes;
    public GameObject[] Gloves; 
    public GameObject[] Headparts;
    public GameObject[] Mounth; 
    public GameObject[] Noise;
    public GameObject[] Combs;
    public GameObject[] Ears;
    public GameObject[] EyesFromHead;
    public GameObject[] Hair;
    public GameObject[] Hat;
    public GameObject[] Horn;
    public GameObject[] Tails;

    public GameObject PlayerDataInit;

    public Init CMainInit;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDataInit = GameObject.FindObjectOfType<Init>().gameObject;
        if(PlayerDataInit != null )
        {
            CMainInit = PlayerDataInit.GetComponent<Init>();
            CheckPlayerItemsAtChar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (PlayerDataInit == null)
            {
                PlayerDataInit = GameObject.FindObjectOfType<Init>().gameObject;
            }

            if(CMainInit == null)
            {
                CMainInit = PlayerDataInit.GetComponent<Init>();
            }
            else
            {
                CheckPlayerItemsAtChar();
            }
        }
    }

    void CheckPlayerItemsAtChar()
    {
        for (int i = 0; i < Bodies.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterBodies[i] > 0) 
            {
                Bodies[i].SetActive(true);
            }
            else
            {
                Bodies[i].SetActive(false);
            }
        }

        for (int i = 0; i < Bodyparts.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterBodyparts[i] > 0)
            {
                Bodyparts[i].SetActive(true);
            }
            else
            {
                Bodyparts[i].SetActive(false);
            }
        }

        for (int i = 0; i < Eyes.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterEyes[i] > 0)
            {
                Eyes[i].SetActive(true);
            }
            else
            {
                Eyes[i].SetActive(false);
            }
        }

        for (int i = 0; i < Gloves.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterGloves[i] > 0)
            {
                Gloves[i].SetActive(true);
            }
            else
            {
                Gloves[i].SetActive(false);
            }
        }

        for (int i = 0; i < Headparts.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterHeadparts[i] > 0)
            {
                Headparts[i].SetActive(true);
            }
            else
            {
                Headparts[i].SetActive(false);
            }
        }

        for (int i = 0; i < Mounth.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterMounth[i] > 0)
            {
                Mounth[i].SetActive(true);
            }
            else
            {
                Mounth[i].SetActive(false);
            }
        }

        for (int i = 0; i < Noise.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterNoise[i] > 0)
            {
                Noise[i].SetActive(true);
            }
            else
            {
                Noise[i].SetActive(false);
            }
        }

        for (int i = 0; i < Combs.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterCombs[i] > 0)
            {
                Combs[i].SetActive(true);
            }
            else
            {
                Combs[i].SetActive(false);
            }
        }

        for (int i = 0; i < Ears.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterEars[i] > 0)
            {
                Ears[i].SetActive(true);
            }
            else
            {
                Ears[i].SetActive(false);
            }
        }

        for (int i = 0; i < EyesFromHead.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterEyesFromHead[i] > 0)
            {
                EyesFromHead[i].SetActive(true);
            }
            else
            {
                EyesFromHead[i].SetActive(false);
            }
        }

        for (int i = 0; i < Hair.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterHair[i] > 0)
            {
                Hair[i].SetActive(true);
            }
            else
            {
                Hair[i].SetActive(false);
            }
        }

        for (int i = 0; i < Hat.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterHat[i] > 0)
            {
                Hat[i].SetActive(true);
            }
            else
            {
                Hat[i].SetActive(false);
            }
        }

        for (int i = 0; i < Horn.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterHorn[i] > 0)
            {
                Horn[i].SetActive(true);
            }
            else
            {
                Horn[i].SetActive(false);
            }
        }

        for (int i = 0; i < Tails.Length; i++)
        {
            if (CMainInit.PlayerData.CharacterTails[i] > 0)
            {
                Tails[i].SetActive(true);
            }
            else
            {
                Tails[i].SetActive(false);
            }
        }
    }
}
