using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class InnAppShop : MonoBehaviour
{
    public Init init;

    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;
    public PlayerDataUIValue playerDataUIValue;

    // Start is called before the first frame update
    void Start()
    {
        init = FindObjectOfType<Init>();
        playerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
    }

    public void BuyRareCard1()
    {
        init.PlayerData.PlayerHardMoney += 1000;
        CheckMoneyTextUI();
    }

    public void BuyRareCard2()
    {
        init.PlayerData.Bodyparts[9] = 1;
        CheckMoneyTextUI();
    }

    public void BuyRareCard3()
    {
        init.PlayerData.Gloves[3] = 1;
        init.PlayerData.Tails[6] = 1;
        init.PlayerData.PlayerMoney += 1000;
        CheckMoneyTextUI();
    }

    public void BuyUncommonCard1()
    {
        init.PlayerData.Bodies[2] = 1;
        init.PlayerData.Bodyparts[1] = 1;
        init.PlayerData.Gloves[1] = 1;
        init.PlayerData.Mounth[7] = 1;
        init.PlayerData.Eyes[5] = 1;
        init.PlayerData.Ears[0] = 1;
        CheckMoneyTextUI();
    }

    public void BuyCommonCard1()
    {
        init.PlayerData.PlayerHardMoney += 100;
        CheckMoneyTextUI();
    }

    public void BuyCommonCard2()
    {
        init.PlayerData.Bodyparts[3] = 1;
        init.PlayerData.Bodyparts[4] = 1;
        init.PlayerData.Bodyparts[5] = 1;
        CheckMoneyTextUI();
    }

    public void BuyCommonCard3()
    {
        init.PlayerData.PlayerHardMoney += 100;
        CheckMoneyTextUI();
    }

    public void BuyEpicCard1()
    {
        init.PlayerData.Bodies[3] = 1;
        init.PlayerData.Bodyparts[2] = 1;
        init.PlayerData.Eyes[7] = 1;
        init.PlayerData.Gloves[3] = 1;
        init.PlayerData.Noise[0] = 1;
        init.PlayerData.Ears[2] = 1;
        init.PlayerData.PlayerMoney += 20000;
        init.PlayerData.PlayerHardMoney += 20000;
        CheckMoneyTextUI();
    }

    public void BuyLegendatyCard1()
    {
        init.PlayerData.Bodies[0] = 1;
        init.PlayerData.Bodyparts[5] = 1;
        init.PlayerData.Eyes[9] = 1;
        init.PlayerData.Gloves[5] = 1;
        init.PlayerData.Noise[1] = 1;
        init.PlayerData.Ears[3] = 1;

        init.PlayerData.Bodies[5] = 1;
        init.PlayerData.Bodyparts[4] = 1;
        init.PlayerData.Eyes[8] = 1;
        init.PlayerData.Gloves[4] = 1;
        init.PlayerData.Mounth[9] = 1;
        init.PlayerData.Combs[0] = 1;


        init.PlayerData.PlayerHardMoney += 30000;
        CheckMoneyTextUI();
    }

    public void BuyMoney1()
    {
        init.PlayerData.PlayerMoney += 50000;
        CheckMoneyTextUI();
    }

    public void BuyHardMoney1()
    {
        init.PlayerData.PlayerHardMoney += 50000;
        CheckMoneyTextUI();
    }

    public void CheckMoneyTextUI() 
    {
        playerDataUIValue.TextValueHardMoney.text = "" + init.PlayerData.PlayerHardMoney;
        playerDataUIValue.TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
    }
}
