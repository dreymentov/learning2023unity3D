using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDataUIValue : MonoBehaviour
{
    public TMP_Text TextValueLevel;
    public TMP_Text TextValueExp;
    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;

    public Init init;

    void Start()
    {
        TextValueLevel.text = "Level: " + init.PlayerData.PlayerLevel;
        TextValueExp.text = "Exp: " + init.PlayerData.PlayerExperience + "/ 100";
        TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
        TextValueHardMoney.text = "" + init.PlayerData.PlayerHardMoney;
    }
}
