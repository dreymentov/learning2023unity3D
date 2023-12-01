using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public GameObject CheckChar;
    public GameObject CanvasMain;
    public GameObject ThisCharacter;
    public CheckCharactersScript CCharScript;
    public Init CMainInit;
    public bool isBodies;
    public bool isBodyparts;
    public bool isEyes;
    public bool isGloves;
    public bool isHeadparts;
    public bool isMounth;
    public bool isNoise;
    public bool isCombs;
    public bool isEars;
    public bool isEyesFromHead;
    public bool isHair;
    public bool isHat;
    public bool isHorn;
    public bool isTails;

    public int idBuy;
    public int idCost;
    public int idCostHard;
    public bool idIsHardMoney;
    public bool isBought;
    public TMP_Text textBuy;
    public void Start()
    {
        CCharScript = CheckChar.GetComponent<CheckCharactersScript>();
        CMainInit = CanvasMain.GetComponent<Init>();
    }

    public void StartBuy()
    {
        if(isBought == false)
        {
            if (isBodies)
            {
                if (CMainInit.PlayerData.Bodies[idBuy] == 0)
                {
                    if(idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Bodies[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                    else if(idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Bodies[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isBodyparts)
            {
                if (CMainInit.PlayerData.Bodyparts[idBuy] == 0)
                {
                    if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Bodyparts[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Bodyparts[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isEyes)
            {
                if (CMainInit.PlayerData.Eyes[idBuy] == 0)
                {
                    if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Eyes[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Eyes[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isGloves)
            {
                if (CMainInit.PlayerData.Gloves[idBuy] == 0)
                {
                    if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                    {
                        CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                        CMainInit.PlayerData.Gloves[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                    else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                    {
                        CMainInit.PlayerData.PlayerMoney -= idCost;
                        CMainInit.PlayerData.Gloves[idBuy] = 1;
                        this.gameObject.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isHeadparts)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Headparts[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Headparts[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isMounth)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Mounth[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Mounth[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isNoise)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Noise[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Noise[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isCombs)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Combs[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Combs[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isEars)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Ears[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Ears[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isEyesFromHead)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.EyesFromHead[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.EyesFromHead[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isHair)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Hair[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Hair[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isHat)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Hat[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Hat[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isHorn)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Horn[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Horn[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
            }
            else if (isTails)
            {
                if (idIsHardMoney == true && CMainInit.PlayerData.PlayerHardMoney >= idCostHard)
                {
                    CMainInit.PlayerData.PlayerHardMoney -= idCostHard;
                    CMainInit.PlayerData.Tails[idBuy] = 1;
                    this.gameObject.SetActive(false);
                }
                else if (idIsHardMoney == false && CMainInit.PlayerData.PlayerMoney >= idCost)
                {
                    CMainInit.PlayerData.PlayerMoney -= idCost;
                    CMainInit.PlayerData.Tails[idBuy] = 1;
                    this.gameObject.SetActive(false);
                } 
            }
            else
            {
                Debug.Log("Try buy nothing");
            }
        }
        else
        {
            if (isBodies)
            {
                if (CMainInit.PlayerData.Bodies[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterBodies[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterBodies[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterBodies[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isBodyparts)
            {
                if (CMainInit.PlayerData.Bodyparts[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if(CMainInit.PlayerData.CharacterBodyparts[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterBodyparts[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterBodyparts[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isEyes)
            {
                if (CMainInit.PlayerData.Eyes[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterEyes[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterEyes[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEyes[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isGloves)
            {
                if (CMainInit.PlayerData.Gloves[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterGloves[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterGloves[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterGloves[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isHeadparts)
            {
                if (CMainInit.PlayerData.Headparts[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterHeadparts[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterHeadparts[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHeadparts[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isMounth)
            {
                if (CMainInit.PlayerData.Mounth[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterMounth[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterMounth[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterMounth[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isNoise)
            {
                if (CMainInit.PlayerData.Noise[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterNoise[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterNoise[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterNoise[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isCombs)
            {
                if (CMainInit.PlayerData.Combs[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterCombs[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterCombs[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterCombs[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isEars)
            {
                if (CMainInit.PlayerData.Ears[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterEars[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterEars[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEars[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isEyesFromHead)
            {
                if (CMainInit.PlayerData.EyesFromHead[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterEyesFromHead[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterEyesFromHead[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterEyesFromHead[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isHair)
            {
                if (CMainInit.PlayerData.Hair[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterHair[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterHair[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHair[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isHat)
            {
                if (CMainInit.PlayerData.Hat[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterHat[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterHat[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHat[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isHorn)
            {
                if (CMainInit.PlayerData.Horn[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterHorn[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterHorn[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterHorn[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
            else if (isTails)
            {
                if (CMainInit.PlayerData.Tails[idBuy] > 0)
                {
                    Debug.LogError("Try Equiping");
                    if (CMainInit.PlayerData.CharacterTails[idBuy] == 0)
                    {
                        CMainInit.PlayerData.CharacterTails[idBuy] = 1;
                    }
                    else
                    {
                        CMainInit.PlayerData.CharacterTails[idBuy] = 0;
                    }
                }
                else
                {
                    Debug.Log("You have it or haven't money");
                }
            }
        }
        
        /*else if (is)
        {
            if (CMainInit.PlayerData.[idBuy] == 0)
            {
                CMainInit.PlayerData.[idBuy] = 1;
            }
        }*/

    }

    public void OnEnable()
    {
        CanvasMain = FindObjectOfType<Init>().gameObject;
        CMainInit = CanvasMain.GetComponent<Init>();
    }

    public void OnDisable()
    {
        
    }
    private void Update()
    {
        if(isBought == false)
        {
            textBuy.text = "Buy";
        }
        else
        {
            textBuy.text = "Equip";
        }
    }
}
