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

    public void Start()
    {
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
        var cam = CmVcam.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = CameraTargetTimeShop.transform;
        cam.LookAt = CameraTargetTimeShop.transform;
        ButtonMenu.SetActive(true);
        ButtonShop.SetActive(false);
        ButtonStart.SetActive(false);
        ButtonExit.SetActive(false);
        PanelShop.SetActive(true);
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
