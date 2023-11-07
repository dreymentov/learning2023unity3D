using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject CheckChar;
    public GameObject CanvasMain;
    public GameObject ThisCharacter;
    public CheckCharactersScript CCharScript;
    public Init CMainInit;
    public void Start()
    {
        CCharScript = CheckChar.GetComponent<CheckCharactersScript>();
        CMainInit = CanvasMain.GetComponent<Init>();
    }

    public void StartBuy()
    {
        int cost = ThisCharacter.GetComponent<ShopCharacter>().CostForBuy;
        if (CMainInit.PlayerData.PlayerCharId[CCharScript.goId] == false)
        {
            if(CMainInit.PlayerData.PlayerMoney >= cost)
            {
                CMainInit.PlayerData.PlayerMoney -= cost;
                CanvasMain.GetComponent<PlayerDataUIValue>().TextValueMoney.text = "" + CMainInit.PlayerData.PlayerMoney;
                CMainInit.PlayerData.PlayerCharId[CCharScript.goId] = true;
                ThisCharacter.GetComponent<ShopCharacter>().isBuyOrNot = true;
                ThisCharacter.GetComponent<ShopCharacter>().Bought.SetActive(true);
                ThisCharacter.GetComponent<ShopCharacter>().Cost.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnEnable()
    {
        CanvasMain = FindObjectOfType<Init>().gameObject;
        CMainInit = CanvasMain.GetComponent<Init>();
        CheckChar = FindObjectOfType<CheckCharactersScript>().gameObject;
        CCharScript = CheckChar.GetComponent<CheckCharactersScript>();
    }

    public void OnDisable()
    {
        if (CMainInit.PlayerData.PlayerCharId[CCharScript.goId] == false)
        {
            CCharScript.goCharacters[CCharScript.goId].SetActive(false);
            CCharScript.goId = 29;
            CCharScript.goCharacters[CCharScript.goId].SetActive(true);
        }
    }
}
