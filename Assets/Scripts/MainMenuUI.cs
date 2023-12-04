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
    public GameObject ButtonBuy;
    public GameObject PanelShop;
    public GameObject[] Scrolls;
    public GameObject panelSetting;

    public GameObject ImageTextFirstGame;
    public GameObject ImageTextFirstGameShop;

    public PlayerDataUIValue PlayerDataUIValue;
    public bool FirstTime;
    public bool FirstTimeShop;

    [Header("Inn App Shop")]
    public GameObject PanelInnShop;
    public GameObject ButtonInnShop;

    public List<ShopCharacter> ShopChars;


    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        PlayerUILevelExp = GameObject.FindGameObjectWithTag("PlayerUILevelPanel");
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
                ButtonMenuFromShop.SetActive(true);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);

                Scrolls[0].SetActive(true);
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
                ButtonMenuFromShop.SetActive(true);
                PlayerUILevelExp.SetActive(false);
                PanelShop.SetActive(true);
                PanelInnShop.SetActive(false);

                Scrolls[0].SetActive(true);
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
        ButtonBuy.SetActive(false);
        ButtonMenuFromShop.SetActive(false);
        PanelShop.SetActive(false);
        PanelInnShop.SetActive(false);
        panelSetting.SetActive(false);
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
    }

    public void GoToInnShop()
    {

        if(FirstTime == false)
        {
            if(PanelInnShop.gameObject.active == false)
            {
                ButtonStart.SetActive(false);
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
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[0].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopBodyParts()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[1].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEyes()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[2].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopGloves()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[3].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopHeadparts()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[4].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void ShopMounth()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[5].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopNoise()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[6].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopEars()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[7].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHair()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[8].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHat()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[9].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopHorn()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[10].SetActive(true);
        ButtonBuy.SetActive(false);
    }
    public void ShopTails()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        foreach (var scroll in Scrolls)
        {
            scroll.SetActive(false);
        }
        Scrolls[11].SetActive(true);
        ButtonBuy.SetActive(false);
    }

    public void GoToSetting()
    {
        foreach (var ShopChar in ShopChars)
        {
            ShopChar.CheckHasItorNotForTakeoff();
        }
        //ShopChars[0].CheckHasItorNotForTakeoffForLook();
        if (FirstTime == false)
        {
            if (panelSetting.gameObject.active == false)
            {
                ButtonStart.SetActive(false);
                PlayerUILevelExp.SetActive(false);
                ButtonMenuFromShop.SetActive(true);
                PanelShop.SetActive(false);
                PanelInnShop.SetActive(false);
                panelSetting.SetActive(true);
            }
            else
            {
                ExitToMainMenu();
            }
        }
    }
}
