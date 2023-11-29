using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class MainMenuUI : MonoBehaviour
{
    public GameObject CameraTargetStart;
    public GameObject CameraTargetTimeShop;
    public GameObject CmVcam;
    public GameObject PlayerUILevelExp;
    public GameObject ButtonMenu;
    public GameObject ButtonMenuFromShop;
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

    [Header("Inn App Shop")]
    public GameObject PanelInnShop;
    public GameObject ButtonInnShop;


    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        PlayerUILevelExp = GameObject.FindGameObjectWithTag("PlayerUILevelPanel");
        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;
        FirstTimeShop = PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop;

        if ((FirstTime == true) && (FirstTimeShop == false))
        {
            ImageTextFirstGame.gameObject.SetActive(true);
            ButtonExit.gameObject.SetActive(false);
        }
        else
        {
            ImageTextFirstGame.gameObject.SetActive(false);
            
        }

        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            ImageTextFirstGameShop.gameObject.SetActive(true);
            ButtonExit.gameObject.SetActive(false);
        }
        else
        {
            ImageTextFirstGameShop.gameObject.SetActive(false);
            ButtonExit.gameObject.SetActive(true);
        }
        ButtonMenuFromShop.SetActive(false);
        PanelShop.SetActive(false);
        ButtonBuy.SetActive(false);
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
    }

    public void StartShopping()
    {
        if ((FirstTime == true) && (FirstTimeShop == true))
        {
            if(PanelShop.gameObject.active == false)
            {
                if (ImageTextFirstGameShop.gameObject.active == true)
                {
                    ImageTextFirstGameShop.gameObject.SetActive(false);
                }

                PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay = false;
                PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop = false;
                FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;
                FirstTimeShop = PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop;

                var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
                cam.Follow = CameraTargetTimeShop.transform;
                cam.LookAt = CameraTargetTimeShop.transform;
                ButtonStart.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                ButtonExit.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);
            }
            else
            {
                ExitToMainMenu();
            }
        }
        else if ((FirstTime == true) && (FirstTimeShop == false))
        {
            return;
        }
        else
        {
            if (PanelShop.gameObject.active == false)
            {
                var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
                cam.Follow = CameraTargetTimeShop.transform;
                cam.LookAt = CameraTargetTimeShop.transform;
                ButtonStart.SetActive(false);
                ButtonExit.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PlayerUILevelExp.SetActive(false);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);
            }
            else
            {
                ExitToMainMenu();
            }
        }
    }

    public void ExitToMainMenu()
    {
        var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = CameraTargetStart.transform;
        cam.LookAt = CameraTargetStart.transform;
        ButtonStart.SetActive(true);
        PlayerUILevelExp.SetActive(true);
        ButtonExit.SetActive(true);
        ButtonBuy.SetActive(false);
        ButtonMenuFromShop.SetActive(false);
        PanelShop.SetActive(false);
        PanelInnShop.SetActive(false);
    }

    public void GoToInnShop()
    {

        if(FirstTime == false)
        {
            if(PanelInnShop.gameObject.active == false)
            {
                ButtonStart.SetActive(false);
                ButtonExit.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                PanelShop.SetActive(false);
                PanelInnShop.SetActive(true); 
                ButtonMenuFromShop.SetActive(true);
            }
            else
            {
                ExitToMainMenu();
            }
            
        }
    }

    public void ShopBody()
    {
        foreach(var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[0].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopBodyParts()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[1].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEyes()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[2].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopGloves()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[3].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopHeadparts()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[4].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopMounth()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[5].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopNoise()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[6].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEars()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[7].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHair()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[8].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHat()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[9].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHorn()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[10].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopTails()
    {
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[11].SetActive(true);
        ButtonBuy.SetActive(false);
    }
}
