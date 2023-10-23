using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public PlayerData PlayerData;

    public static Init Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
