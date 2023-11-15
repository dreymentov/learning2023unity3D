using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[System.Serializable]
public class PlayerData
{
    public int PlayerLevel = 1;
    public int PlayerExperience = 1;
    public int PlayerMoney = 100;
    public int PlayerHardMoney = 10;
    public int PlayerCharIdCheck = 29;

    public bool mobile;

    public bool[] PlayerCharId = new bool[30];
}


