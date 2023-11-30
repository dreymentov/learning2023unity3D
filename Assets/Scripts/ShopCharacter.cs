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
    public GameObject MainCanvas;
    public GameObject ButtonBuy;
    public GameObject Equip;

    public PlayerDataUIValue MCanvas;
    public PlayerData PDShop;

    public int CostForBuy = 999;
    public int ItemId = 999;

    public bool isBuyOrNot;
    public bool isEquip;

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
        }
        else
        {
            Debug.Log("Cant loading Player Data for Shop");
        }

        CheckItemsIdInit();
    }

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        if(PDShop == null)
        {
            PDShop = MainCanvas.GetComponent<PlayerData>();
        }
        CheckItemsIdInit();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ButtonBuy.SetActive(false);
        CheckItemsIdInit();

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        CheckItemsIdInit();
    }

    public void BuyCharacter()
    {
        CheckItemsIdInit();

        if ( isBuyOrNot == false)
        {
            Cost.gameObject.SetActive(true);
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
            Bought.gameObject.SetActive(true);
            Cost.gameObject.SetActive(false);
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

                if (PDShop.CharacterBodies[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isBodyparts == true)
        {
            if (Bodyparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterBodyparts[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isEyes == true)
        {
            if (Eyes[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyes[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isGloves == true)
        {
            if (Gloves[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterGloves[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isHeadparts == true)
        {
            if (Headparts[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHeadparts[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isMounth == true)
        {
            if (Mounth[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterMounth[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isNoise == true)
        {
            if (Noise[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterNoise[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isCombs == true)
        {
            if (Combs[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterCombs[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isEars == true)
        {
            if (Ears[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEars[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isEyesFromHead == true)
        {
            if (EyesFromHead[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterEyesFromHead[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isHair == true)
        {
            if (Hair[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHair[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isHat == true)
        {
            if (Hat[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHat[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isHorn == true)
        {
            if (Horn[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterHorn[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
        }
        else if (isTails == true)
        {
            if (Tails[ItemId] == 1)
            {
                isBuyOrNot = true;

                if (PDShop.CharacterTails[ItemId] == 1)
                {
                    isEquip = true;
                }
                else
                {
                    isEquip = false;
                }
            }
            else isBuyOrNot = false;
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
            Cost.SetActive(true);
        }
        else
        {
            if(isEquip == false)
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
        }
    }
}
