using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject CameraTargetStart;
    public GameObject CameraTargetTimeShop;
    public GameObject CmVcam;
    public GameObject ButtonMenu;
    public GameObject ButtonShop;
    public GameObject ButtonStart;
    public GameObject ButtonExit;
    public GameObject ButtonBuy;
    public GameObject PanelShop;
    public GameObject[] Scrolls;

    public GameObject ImageTextFirstGame;
    public GameObject ImageTextFirstGameShop;

    public PlayerDataUIValue PlayerDataUIValue;
    public bool FirstTime;
    public bool FirstTimeShop;

    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;
        FirstTimeShop = PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop;

        if ((FirstTime == true) && (FirstTimeShop == false))
        {
            ImageTextFirstGame.gameObject.SetActive(true);
        }
        else
        {
            ImageTextFirstGame.gameObject.SetActive(false);
        }

        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            ImageTextFirstGameShop.gameObject.SetActive(true);
        }
        else
        {
            ImageTextFirstGameShop.gameObject.SetActive(false);
        }

        ButtonMenu.SetActive(false);
        ButtonShop.SetActive(true);
        PanelShop.SetActive(false);
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
    }

    public void StartShopping()
    {
        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            if (ImageTextFirstGameShop.gameObject.active == true)
            {
                ImageTextFirstGameShop.gameObject.SetActive(false);
            }

            PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay = false;
            PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop = false;

            var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
            cam.Follow = CameraTargetTimeShop.transform;
            cam.LookAt = CameraTargetTimeShop.transform;
            ButtonMenu.SetActive(true);
            ButtonShop.SetActive(false);
            ButtonStart.SetActive(false);
            ButtonExit.SetActive(false);
            PanelShop.SetActive(true);
        }
        else if ((FirstTime == true) && (FirstTimeShop == false))
        {
            return;
        }
        else
        {
            var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
            cam.Follow = CameraTargetTimeShop.transform;
            cam.LookAt = CameraTargetTimeShop.transform;
            ButtonMenu.SetActive(true);
            ButtonShop.SetActive(false);
            ButtonStart.SetActive(false);
            ButtonExit.SetActive(false);
            PanelShop.SetActive(true);
        }
    }

    public void ExitToMainMenu()
    {
        var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = CameraTargetStart.transform;
        cam.LookAt = CameraTargetStart.transform;
        ButtonMenu.SetActive(false);
        ButtonShop.SetActive(true);
        ButtonStart.SetActive(true);
        ButtonExit.SetActive(true);
        ButtonBuy.SetActive(false);
        PanelShop.SetActive(false);
    }

    public void ShopChar()
    {
        foreach(var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[0].SetActive(true);
    }

    public void ShopColor()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[1].SetActive(true);
    }
    public void ShopTop()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[2].SetActive(true);
    }
    public void ShopBot()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[3].SetActive(true);
    }
}
