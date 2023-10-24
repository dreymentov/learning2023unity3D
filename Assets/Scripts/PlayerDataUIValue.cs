using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class PlayerDataUIValue : MonoBehaviour
{
    public TMP_Text TextValueLevel;
    public TMP_Text TextValueExp;
    public TMP_Text TextValueMoney;
    public TMP_Text TextValueHardMoney;
    public TMP_Text TextExpPanelReward;
    public TMP_Text TextMoneyPanelReward;
    public TMP_Text TextLevelUp;

    public Slider Slider;

    public RectTransform PanelMain;
    public RectTransform PanelShowReward;
    public RectTransform PanelShowSummary;
    public RectTransform PanelLevelUp;
    public RectTransform PanelLevelUpBackground;

    public RectTransform[] RewardsPanelInPanelShowReward;
    public Image[] RewardsImageInPanelShowReward;

    public bool isLevelUp = false;

    private int j = 0;
    private int l = 0;

    public int SliderMaxValue = 100;
    public int PlaceInLevel = 999;

    public Init init;

    [SerializeField] private int MoneyReward = 0;
    [SerializeField] private int HardMoneyReward = 0;
    [SerializeField] private int ExpReward = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PlaceInLevel = 999;
            PanelMain.gameObject.SetActive(false);
            TextValueLevel.text = /*"Level: " */ "" + init.PlayerData.PlayerLevel;
            TextValueExp.text = /*"Exp: " */ "" + init.PlayerData.PlayerExperience + "/ 100";
            TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
            TextValueHardMoney.text = "" + init.PlayerData.PlayerHardMoney;
        }
        else if (SceneManager.GetActiveScene().name == "Lobby")
        {
            PanelMain.gameObject.SetActive(true);

            TextExpPanelReward.text = "";
            TextMoneyPanelReward.text = "";

            TextLevelUp.color = new Color(1f, 1f, 1f, 0f);

            TextValueLevel.text = "" + init.PlayerData.PlayerLevel;
            TextValueExp.text = "" + init.PlayerData.PlayerExperience + "/ 100";
            TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
            TextValueHardMoney.text = "" + init.PlayerData.PlayerHardMoney;

            

            Slider.maxValue = SliderMaxValue;
            Slider.value = init.PlayerData.PlayerExperience;

            if (PlaceInLevel == 5)
            {
                MoneyReward = 25;
                HardMoneyReward = 2;
                ExpReward = 10;
            }
            else if (PlaceInLevel == 4)
            {
                MoneyReward = 50;
                HardMoneyReward = 5;
                ExpReward = 20;
            }
            else if (PlaceInLevel == 3)
            {
                MoneyReward = 100;
                HardMoneyReward = 10;
                ExpReward = 30;
            }
            else if (PlaceInLevel == 2)
            {
                MoneyReward = 150;
                HardMoneyReward = 15;
                ExpReward = 40;
            }
            else if (PlaceInLevel == 1)
            {
                MoneyReward = 200;
                HardMoneyReward = 20;
                ExpReward = 50;
            }
            else
            {
                MoneyReward = 0;
                HardMoneyReward = 0;
                ExpReward = 0;
            }

            StartCoroutine(GetReward());
        }
        else if (SceneManager.GetActiveScene().name == "Level1")
        {
            PanelMain.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            PanelMain.gameObject.SetActive(false);
        }
        else
        {
            PanelMain.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            PanelMain.gameObject.SetActive(true);

            if (isLevelUp == true)
            {
                if (PanelLevelUp.gameObject.activeSelf == true)
                {
                    if (Input.GetKeyUp("escape"))
                    {
                        PanelLevelUp.gameObject.SetActive(false);
                        PanelLevelUpBackground.gameObject.SetActive(false);
                    }
                }
                else if (PanelLevelUp.gameObject.activeSelf == false)
                {
                    if (Input.GetKeyUp("escape"))
                    {
                        PanelLevelUp.gameObject.SetActive(true);
                        PanelLevelUpBackground.gameObject.SetActive(true);
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            PanelMain.gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PanelMain.gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            PanelMain.gameObject.SetActive(false);
        }
    }

    IEnumerator ResultCount()
    {
        yield return null;
    }

    IEnumerator GetReward()
    {
        for(int i = 0; i < RewardsPanelInPanelShowReward.Length; i++)
        {
            RewardsImageInPanelShowReward[i].color = Random.ColorHSV();
            RewardsPanelInPanelShowReward[i].DOScale(new Vector3(1, 1, 1), 1.5f);

            for (int j = 0; j < 10; j++)
            {
                Color ColorImage = RewardsImageInPanelShowReward[i].color;
                ColorImage.a = j * 0.1f;
                RewardsImageInPanelShowReward[i].color = ColorImage;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.0f);
        }
        
        for (int i = 0; i < 10; i++)
        {
            j += Random.Range(0, ExpReward / 100);
            l += Random.Range(0, MoneyReward / 100);
            TextExpPanelReward.text = ""+j;
            TextMoneyPanelReward.text = ""+l;
            yield return new WaitForSeconds(0.075f);
        }
        for (int i = 0; i < 10; i++)
        {
            j += Random.Range(ExpReward / 100, ExpReward / 10);
            l += Random.Range(MoneyReward / 100, MoneyReward / 10);
            TextExpPanelReward.text = "" + j;
            TextMoneyPanelReward.text = "" + l;
            yield return new WaitForSeconds(0.075f);
        }

        TextExpPanelReward.text = "" + ExpReward;
        TextMoneyPanelReward.text = "" + MoneyReward;

        init.PlayerData.PlayerMoney += MoneyReward;
        TextValueMoney.text = "" + init.PlayerData.PlayerMoney;

        for (int i = 0; i < ExpReward - 1; i++)
        {
            Slider.value = init.PlayerData.PlayerExperience;
            Slider.value++;
            TextValueExp.text = "" + Slider.value + "/ 100";
            yield return new WaitForSeconds(0.02f);

            if (Slider.value == Slider.maxValue)
            {
                Slider.value = 0;
                TextValueExp.text = "" + Slider.value + "/ 100";
                Color tluColor = TextLevelUp.color;
                for(int k = 0; k < 10; k++)
                {
                    tluColor.a = 0.1f * k;
                    TextLevelUp.color = tluColor;
                    yield return new WaitForSeconds(0.05f);
                }
                init.PlayerData.PlayerLevel++;
                TextValueLevel.text = "" + init.PlayerData.PlayerLevel;
                init.PlayerData.PlayerHardMoney += HardMoneyReward;

                PanelLevelUp.gameObject.SetActive(true);
                PanelLevelUpBackground.gameObject.SetActive(true);
                isLevelUp = true;
                PanelLevelUp.DOScale(new Vector3(1f, 1f, 1f), 2f);
                init.PlayerData.PlayerMoney += 500;
                TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
                yield return new WaitForSeconds(2f);
            }

            init.PlayerData.PlayerExperience = (int)Slider.value;
        } 
        yield break;
    }
}
