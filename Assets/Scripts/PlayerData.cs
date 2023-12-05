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
    public bool PlayerFirstTimePlay = true;
    public bool PlayerFirstTimeNeedShop = false;
    public int GameFinished = 0;

    public int[] Bodies = { 0, 1, 0, 0, 0, 0 };
    public int[] Bodyparts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Eyes = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Gloves = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Headparts = { 0, 0, 0, 0 };
    public int[] Mounth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] Noise = { 0, 0, 0, 0, 0 };
    public int[] Combs = { 0 };
    public int[] Ears = { 0, 0, 0, 0 };
    public int[] EyesFromHead = { 0, 0, 0, 0 };
    public int[] Hair = { 0, 0 };
    public int[] Hat = { 0, 0, 0, 0, 0 };
    public int[] Horn = { 0, 0, 0, 0 };
    public int[] Tails = { 0, 0, 0, 0, 0, 0, 0, 0 };

    public int[] CharacterBodies = { 0, 1, 0, 0, 0, 0 };
    public int[] CharacterBodyparts = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] CharacterEyes = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] CharacterGloves = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] CharacterHeadparts = { 0, 0, 0, 0 };
    public int[] CharacterMounth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] CharacterNoise = { 0, 0, 0, 0, 0 };
    public int[] CharacterCombs = { 0 };
    public int[] CharacterEars = { 0, 0, 0, 0 };
    public int[] CharacterEyesFromHead = { 0, 0, 0, 0 };
    public int[] CharacterHair = { 0, 0 };
    public int[] CharacterHat = { 0, 0, 0, 0, 0 };
    public int[] CharacterHorn = { 0, 0, 0, 0 };
    public int[] CharacterTails = { 0, 0, 0, 0, 0, 0, 0, 0 };
}


