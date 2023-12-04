using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopCharacter : MonoBehaviour
{
    public GameObject Bought;
    public GameObject Cost;
    public GameObject CostHard;
    public GameObject MainCanvas;
    public GameObject ButtonBuy;
    public GameObject Equip;

    public PlayerDataUIValue MCanvas;
    public PlayerData PDShop;
    public PlayerItemsInChar PlayerChar;

    public int CostForBuy = 999;
    public int CostHardForBuy = 999;
    public int ItemId = 999;

    public bool isBuyOrNot;
    public bool isEquip;
    public bool isBuyByHardMoney;

    [Header("Items Id Shop from Player Data w Init")]

    public int[] Bodies;
    public int[] Bodyparts;
    public int[] Eyes;
    public int[] Gloves;
    public int[] Headparts;
    public int[] Mounth;
    public int[] Noise;
    public int[] Combs;
    public int[] Ears;
    public int[] EyesFromHead;
    public int[] Hair;
    public int[] Hat;
    public int[] Horn;
    public int[] Tails;

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

    // Start is called before the first frame update
    void Start()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        PDShop = MainCanvas.gameObject.GetComponent<Init>().PlayerData;
        Cost.GetComponent<TMP_Text>().text = "" + CostForBuy;
        CostHard.GetComponent<TMP_Text>().text = "" + CostHardForBuy;
        ButtonBuy.SetActive(false);

        if (PDShop != null)
        {
            Bodies = PDShop.Bodies;
            Bodyparts = PDShop.Bodyparts;
            Eyes = PDShop.Eyes;
            Gloves = PDShop.Gloves;
            Headparts = PDShop.Headparts;
            Mounth = PDShop.Mounth;
            Noise = PDShop.Noise;
            Combs = PDShop.Combs;
            Ears = PDShop.Ears;
            EyesFromHead = PDShop.EyesFromHead;
            Hair = PDShop.Hair;
            Hat = PDShop.Hat;
            Horn = PDShop.Horn;
            Tails = PDShop.Tails;

            CheckIsBoughtOrNot();
        }
        else
        {
            Debug.Log("Cant loading Player Data for Shop");
        }

        //CheckItemsIdInit();
    }

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        if (PDShop == null)
        {
            PDShop = MainCanvas.GetComponent<PlayerData>();
        }
        //CheckItemsIdInit();
        CheckIsBoughtOrNot();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ButtonBuy.SetActive(false);
        //CheckItemsIdInit();
        CheckIsBoughtOrNot();

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        CheckIsBoughtOrNot();
        //CheckItemsIdInit();
    }

    public void BuyCharacter()
    {
        CheckHasItorNotForTakeoffForLook();
        CheckIsBoughtOrNot();
        CheckItemsIdInit();

        if (isBuyOrNot == false)
        {
            if (isBuyByHardMoney == true)
            {
                Cost.gameObject.SetActive(false);
                CostHard.gameObject.SetActive(true);
            }
            else
            {
                Cost.gameObject.SetActive(true);
                CostHard.gameObject.SetActive(false);
            }
            Bought.gameObject.SetActive(false);

            if (ButtonBuy.gameObject.active == false)
            {

                ButtonBuy.SetActive(true);
            }
            else
            {

            }
            // IF NEED BUY ONE ITEM, NO SKIN + PARTS, ONLY ONE ITEM BUY
            ButtonBuy.GetComponent<BuyButton>().isBodies = isBodies;
            ButtonBuy.GetComponent<BuyButton>().isBodyparts = isBodyparts;
            ButtonBuy.GetComponent<BuyButton>().isEyes = isEyes;
            ButtonBuy.GetComponent<BuyButton>().isGloves = isGloves;
            ButtonBuy.GetComponent<BuyButton>().isHeadparts = isHeadparts;
            ButtonBuy.GetComponent<BuyButton>().isMounth = isMounth;
            ButtonBuy.GetComponent<BuyButton>().isNoise = isNoise;
            ButtonBuy.GetComponent<BuyButton>().isCombs = isCombs;
            ButtonBuy.GetComponent<BuyButton>().isEars = isEars;
            ButtonBuy.GetComponent<BuyButton>().isEyesFromHead = isEyesFromHead;
            ButtonBuy.GetComponent<BuyButton>().isHair = isHair;
            ButtonBuy.GetComponent<BuyButton>().isHat = isHat;
            ButtonBuy.GetComponent<BuyButton>().isHorn = isHorn;
            ButtonBuy.GetComponent<BuyButton>().isTails = isTails;
            ButtonBuy.GetComponent<BuyButton>().idBuy = ItemId;
            ButtonBuy.GetComponent<BuyButton>().idCost = CostForBuy;
            ButtonBuy.GetComponent<BuyButton>().idCostHard = CostHardForBuy;
            ButtonBuy.GetComponent<BuyButton>().idIsHardMoney = isBuyByHardMoney;
            ButtonBuy.GetComponent<BuyButton>().isBought = false;

        }
        else
        {
            ButtonBuy.GetComponent<BuyButton>().isBodies = isBodies;
            ButtonBuy.GetComponent<BuyButton>().isBodyparts = isBodyparts;
            ButtonBuy.GetComponent<BuyButton>().isEyes = isEyes;
            ButtonBuy.GetComponent<BuyButton>().isGloves = isGloves;
            ButtonBuy.GetComponent<BuyButton>().isHeadparts = isHeadparts;
            ButtonBuy.GetComponent<BuyButton>().isMounth = isMounth;
            ButtonBuy.GetComponent<BuyButton>().isNoise = isNoise;
            ButtonBuy.GetComponent<BuyButton>().isCombs = isCombs;
            ButtonBuy.GetComponent<BuyButton>().isEars = isEars;
            ButtonBuy.GetComponent<BuyButton>().isEyesFromHead = isEyesFromHead;
            ButtonBuy.GetComponent<BuyButton>().isHair = isHair;
            ButtonBuy.GetComponent<BuyButton>().isHat = isHat;
            ButtonBuy.GetComponent<BuyButton>().isHorn = isHorn;
            ButtonBuy.GetComponent<BuyButton>().isTails = isTails;
            ButtonBuy.SetActive(true);
            ButtonBuy.GetComponent<BuyButton>().isBought = true;
            ButtonBuy.GetComponent<BuyButton>().idBuy = ItemId;
        }
    }

    public void CheckItemsIdInit() // for one item buy
    {
        Bodies = PDShop.Bodies;
        Bodyparts = PDShop.Bodyparts;
        Eyes = PDShop.Eyes;
        Gloves = PDShop.Gloves;
        Headparts = PDShop.Headparts;
        Mounth = PDShop.Mounth;
        Noise = PDShop.Noise;
        Combs = PDShop.Combs;
        Ears = PDShop.Ears;
        EyesFromHead = PDShop.EyesFromHead;
        Hair = PDShop.Hair;
        Hat = PDShop.Hat;
        Horn = PDShop.Horn;
        Tails = PDShop.Tails;

        if (isBodies == true)
        {
            if (Bodies[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterBodies[ItemId] == 0)
                {
                    PDShop.CharacterBodies[ItemId] = 1;
                    isEquip = true;
                    Bought.gameObject.SetActive(false);
                }
                else
                {
                    PDShop.CharacterBodies[ItemId] = 0;
                    isEquip = false;
                    Bought.gameObject.SetActive(true);
                }
            }
            else
            {
                if (PDShop.CharacterBodies[ItemId] == 1)
                {
                    PDShop.CharacterBodies[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterBodies[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isBodyparts == true)
        {
            if (Bodyparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterBodyparts[ItemId] == 0)
                {
                    PDShop.CharacterBodyparts[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterBodyparts[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterBodyparts[ItemId] == 1)
                {
                    PDShop.CharacterBodyparts[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterBodyparts[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isEyes == true)
        {
            if (Eyes[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyes[ItemId] == 0)
                {
                    PDShop.CharacterEyes[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterEyes[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterEyes[ItemId] == 1)
                {
                    PDShop.CharacterEyes[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterEyes[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isGloves == true)
        {
            if (Gloves[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterGloves[ItemId] == 0)
                {
                    PDShop.CharacterGloves[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterGloves[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterGloves[ItemId] == 1)
                {
                    PDShop.CharacterGloves[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterGloves[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isHeadparts == true)
        {
            if (Headparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHeadparts[ItemId] == 0)
                {
                    PDShop.CharacterHeadparts[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterHeadparts[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterHeadparts[ItemId] == 1)
                {
                    PDShop.CharacterHeadparts[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterHeadparts[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isMounth == true)
        {
            if (Mounth[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterMounth[ItemId] == 0)
                {
                    PDShop.CharacterMounth[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterMounth[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterMounth[ItemId] == 1)
                {
                    PDShop.CharacterMounth[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterMounth[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isNoise == true)
        {
            if (Noise[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterNoise[ItemId] == 0)
                {
                    PDShop.CharacterNoise[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterNoise[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterNoise[ItemId] == 1)
                {
                    PDShop.CharacterNoise[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterNoise[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isCombs == true)
        {
            if (Combs[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterCombs[ItemId] == 0)
                {
                    PDShop.CharacterCombs[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterCombs[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterCombs[ItemId] == 1)
                {
                    PDShop.CharacterCombs[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterCombs[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isEars == true)
        {
            if (Ears[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEars[ItemId] == 0)
                {
                    PDShop.CharacterEars[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterEars[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterEars[ItemId] == 1)
                {
                    PDShop.CharacterEars[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterEars[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isEyesFromHead == true)
        {
            if (EyesFromHead[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyesFromHead[ItemId] == 0)
                {
                    PDShop.CharacterEyesFromHead[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterEyesFromHead[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterEyesFromHead[ItemId] == 1)
                {
                    PDShop.CharacterEyesFromHead[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterEyesFromHead[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isHair == true)
        {
            if (Hair[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHair[ItemId] == 0)
                {
                    PDShop.CharacterHair[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterHair[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterHair[ItemId] == 1)
                {
                    PDShop.CharacterHair[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterHair[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isHat == true)
        {
            if (Hat[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHat[ItemId] == 0)
                {
                    PDShop.CharacterHat[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterHat[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterHat[ItemId] == 1)
                {
                    PDShop.CharacterHat[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterHat[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isHorn == true)
        {
            if (Horn[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHorn[ItemId] == 0)
                {
                    PDShop.CharacterHorn[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterHorn[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterHorn[ItemId] == 1)
                {
                    PDShop.CharacterHorn[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterHorn[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else if (isTails == true)
        {
            if (Tails[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterTails[ItemId] == 0)
                {
                    PDShop.CharacterTails[ItemId] = 1;
                    isEquip = true;
                }
                else
                {
                    PDShop.CharacterTails[ItemId] = 0;
                    isEquip = false;
                }
            }
            else
            {
                if (PDShop.CharacterTails[ItemId] == 1)
                {
                    PDShop.CharacterTails[ItemId] = 0;
                    isEquip = false;
                }
                else
                {
                    PDShop.CharacterTails[ItemId] = 1;
                    isEquip = true;
                }
                isBuyOrNot = false;
            }
        }
        else
        {
            Debug.Log("What do you want to buy?");
        }
        /*else if (is)
        {
            if ([ItemId] > 0)
            {
                isBuyOrNot = true;
            }
            else isBuyOrNot = false;
        }*/
        if (isBuyOrNot == false)
        {
            Equip.SetActive(false);
            Bought.SetActive(false);
            if (isBuyByHardMoney == true)
            {
                Cost.gameObject.SetActive(false);
                CostHard.gameObject.SetActive(true);
            }
            else
            {
                Cost.gameObject.SetActive(true);
                CostHard.gameObject.SetActive(false);
            }
        }
        else
        {
            if (isEquip == false)
            {
                Bought.SetActive(true);
                Equip.SetActive(false);
            }
            else
            {
                Bought.SetActive(false);
                Equip.SetActive(true);
            }
            Cost.SetActive(false);
            CostHard.SetActive(false);
        }
    }

    public void CheckIsBoughtOrNot()
    {
        Bodies = PDShop.Bodies;
        Bodyparts = PDShop.Bodyparts;
        Eyes = PDShop.Eyes;
        Gloves = PDShop.Gloves;
        Headparts = PDShop.Headparts;
        Mounth = PDShop.Mounth;
        Noise = PDShop.Noise;
        Combs = PDShop.Combs;
        Ears = PDShop.Ears;
        EyesFromHead = PDShop.EyesFromHead;
        Hair = PDShop.Hair;
        Hat = PDShop.Hat;
        Horn = PDShop.Horn;
        Tails = PDShop.Tails;

        if (isBodies == true)
        {
            if (Bodies[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterBodies[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isBodyparts == true)
        {
            if (Bodyparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterBodyparts[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isEyes == true)
        {
            if (Eyes[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyes[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isGloves == true)
        {
            if (Gloves[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterGloves[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isHeadparts == true)
        {
            if (Headparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHeadparts[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isMounth == true)
        {
            if (Mounth[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterMounth[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isNoise == true)
        {
            if (Noise[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterNoise[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isCombs == true)
        {
            if (Combs[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterCombs[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isEars == true)
        {
            if (Ears[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEars[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isEyesFromHead == true)
        {
            if (EyesFromHead[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyesFromHead[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isHair == true)
        {
            if (Hair[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHair[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isHat == true)
        {
            if (Hat[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHat[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isHorn == true)
        {
            if (Horn[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHorn[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }
        else if (isTails == true)
        {
            if (Tails[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterTails[ItemId] == 0)
                {
                    isEquip = false;
                }
                else
                {
                    isEquip = true;
                }
            }
            else
            {
                isBuyOrNot = false;
            }
        }

        if (isBuyOrNot == false)
        {
            Equip.SetActive(false);
            Bought.SetActive(false);
            if (isBuyByHardMoney == true)
            {
                Cost.gameObject.SetActive(false);
                CostHard.gameObject.SetActive(true);
            }
            else
            {
                Cost.gameObject.SetActive(true);
                CostHard.gameObject.SetActive(false);
            }
        }
        else
        {
            if (isEquip == false)
            {
                Bought.SetActive(true);
                Equip.SetActive(false);
            }
            else
            {
                Bought.SetActive(false);
                Equip.SetActive(true);
            }
            Cost.SetActive(false);
            CostHard.SetActive(false);
        }
    }

    public void CheckHasItorNotForTakeoff()
    {
        Bodies = PDShop.Bodies;
        Bodyparts = PDShop.Bodyparts;
        Eyes = PDShop.Eyes;
        Gloves = PDShop.Gloves;
        Headparts = PDShop.Headparts;
        Mounth = PDShop.Mounth;
        Noise = PDShop.Noise;
        Combs = PDShop.Combs;
        Ears = PDShop.Ears;
        EyesFromHead = PDShop.EyesFromHead;
        Hair = PDShop.Hair;
        Hat = PDShop.Hat;
        Horn = PDShop.Horn;
        Tails = PDShop.Tails;

        if (isBodies == true)
        {
            if (Bodies[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterBodies[ItemId] = 0;
            }

            int j = 0;

            for (int i = 0; i < PDShop.CharacterBodies.Length; i++)
            {
                if (PDShop.CharacterBodies[i] == 1)
                {
                    j++;
                }
            }

            if (j == 0)
            {
                for (int i = 0; i < Bodies.Length; i++)
                {
                    if (Bodies[i] == 1)
                    {
                        PDShop.CharacterBodies[i] = 1;
                        break;
                    }
                }
            }

        }
        else if (isBodyparts == true)
        {
            if (Bodyparts[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterBodyparts[ItemId] = 0;
            }
        }
        else if (isEyes == true)
        {
            if (Eyes[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterEyes[ItemId] = 0;
            }

            int j = 0;

            for (int i = 0; i < PDShop.CharacterEyes.Length; i++)
            {
                if (PDShop.CharacterEyes[i] == 1)
                {
                    j++;
                }
            }

            if (j == 0)
            {
                for (int i = 0; i < Eyes.Length; i++)
                {
                    if (Eyes[i] == 1)
                    {
                        PDShop.CharacterEyes[i] = 1;
                        break;
                    }
                }
            }
        }
        else if (isGloves == true)
        {
            if (Gloves[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterGloves[ItemId] = 0;
            }
        }
        else if (isHeadparts == true)
        {
            if (Headparts[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterHeadparts[ItemId] = 0;
            }
        }
        else if (isMounth == true)
        {
            if (Mounth[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterMounth[ItemId] = 0;
            }

            int j = 0;

            for (int i = 0; i < PDShop.CharacterMounth.Length; i++)
            {
                if (PDShop.CharacterMounth[i] == 1)
                {
                    j++;
                }
            }

            if (j == 0)
            {
                for (int i = 0; i < Mounth.Length; i++)
                {
                    if (Mounth[i] == 1)
                    {
                        PDShop.CharacterMounth[i] = 1;
                        break;
                    }
                }
            }
        }
        else if (isNoise == true)
        {
            if (Noise[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterNoise[ItemId] = 0;
            }
        }
        else if (isCombs == true)
        {
            if (Combs[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterCombs[ItemId] = 0;
            }
        }
        else if (isEars == true)
        {
            if (Ears[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterEars[ItemId] = 0;
            }
        }
        else if (isEyesFromHead == true)
        {
            if (EyesFromHead[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterEyesFromHead[ItemId] = 0;
            }
        }
        else if (isHair == true)
        {
            if (Hair[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterHair[ItemId] = 0;
            }
        }
        else if (isHat == true)
        {
            if (Hat[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterHat[ItemId] = 0;
            }
        }
        else if (isHorn == true)
        {
            if (Horn[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterHorn[ItemId] = 0;
            }
        }
        else if (isTails == true)
        {
            if (Tails[ItemId] == 1)
            {

            }
            else
            {
                PDShop.CharacterTails[ItemId] = 0;
            }
        }
    }

    public void CheckHasItorNotForTakeoffForLook()
    {
        Bodies = PDShop.Bodies;
        Bodyparts = PDShop.Bodyparts;
        Eyes = PDShop.Eyes;
        Gloves = PDShop.Gloves;
        Headparts = PDShop.Headparts;
        Mounth = PDShop.Mounth;
        Noise = PDShop.Noise;
        Combs = PDShop.Combs;
        Ears = PDShop.Ears;
        EyesFromHead = PDShop.EyesFromHead;
        Hair = PDShop.Hair;
        Hat = PDShop.Hat;
        Horn = PDShop.Horn;
        Tails = PDShop.Tails;

        if (isBodies == true)
        {
            for (int i = 0; i < Bodies.Length; i++)
            {
                PDShop.CharacterBodies[i] = 0;
            }
        }
        else if (isBodyparts == true)
        {
            for (int i = 0; i < Bodyparts.Length; i++)
            {
                if (Bodyparts[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterBodyparts[i] = 0;
                }
            }
        }
        else if (isEyes == true)
        {
            for (int i = 0; i < Eyes.Length; i++)
            {
                if (Eyes[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterEyes[i] = 0;
                }
            }
        }
        else if (isGloves == true)
        {
            for (int i = 0; i < Gloves.Length; i++)
            {
                if (Gloves[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterGloves[i] = 0;
                }
            }
        }
        else if (isHeadparts == true)
        {
            for (int i = 0; i < Headparts.Length; i++)
            {
                if (Headparts[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterHeadparts[i] = 0;
                }
            }
        }
        else if (isMounth == true)
        {
            for (int i = 0; i < Mounth.Length; i++)
            {
                if (Mounth[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterMounth[i] = 0;
                }
            }
        }
        else if (isNoise == true)
        {
            for (int i = 0; i < Noise.Length; i++)
            {
                if (Noise[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterNoise[i] = 0;
                }
            }
        }
        else if (isCombs == true)
        {
            for (int i = 0; i < Combs.Length; i++)
            {
                if (Combs[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterCombs[i] = 0;
                }
            }
        }
        else if (isEars == true)
        {
            for (int i = 0; i < Ears.Length; i++)
            {
                if (Ears[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterEars[i] = 0;
                }
            }
        }
        else if (isEyesFromHead == true)
        {
            for (int i = 0; i < EyesFromHead.Length; i++)
            {
                if (EyesFromHead[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterEyesFromHead[i] = 0;
                }
            }
        }
        else if (isHair == true)
        {
            for (int i = 0; i < Hair.Length; i++)
            {
                if (Hair[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterHair[i] = 0;
                }
            }
        }
        else if (isHat == true)
        {
            for (int i = 0; i < Hat.Length; i++)
            {
                if (Hat[i] == 1)
                {

                }
                else
                {
                    PDShop.Hat[i] = 0;
                }
            }
        }
        else if (isHorn == true)
        {
            for (int i = 0; i < Horn.Length; i++)
            {
                if (Horn[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterHorn[i] = 0;
                }
            }
        }
        else if (isTails == true)
        {
            for (int i = 0; i < Tails.Length; i++)
            {
                if (Tails[i] == 1)
                {

                }
                else
                {
                    PDShop.CharacterTails[i] = 0;
                }
            }
        }
    }
}
