using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Init init;

    [SerializeField] private int NumberRewardCycle = 0;
    [SerializeField] private int MoneyReward = 400;
    [SerializeField] private int ExpReward = 150;

    void Start()
    {
        TextLevelUp.color = new Color(1f, 1f, 1f, 0f);

        TextValueLevel.text = /*"Level: " */ "" + init.PlayerData.PlayerLevel;
        TextValueExp.text = /*"Exp: " */ "" + init.PlayerData.PlayerExperience + "/ 100";
        TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
        TextValueHardMoney.text = "" + init.PlayerData.PlayerHardMoney;

        Slider.maxValue = SliderMaxValue;
        Slider.value = init.PlayerData.PlayerExperience;

        NumberRewardCycle = 0;
        StartCoroutine(GetReward());
    }

    private void Update()
    {
        if(isLevelUp == true)
        {
            if(PanelLevelUp.gameObject.activeSelf == true)
            {
                if(Input.GetKeyUp("escape"))
                {
                    PanelLevelUp.gameObject.SetActive(false);
                    PanelLevelUpBackground.gameObject.SetActive(false);
                }
            }
            else if(PanelLevelUp.gameObject.activeSelf == false)
            {
                if (Input.GetKeyUp("escape"))
                {
                    PanelLevelUp.gameObject.SetActive(true);
                    PanelLevelUpBackground.gameObject.SetActive(true);
                }
            }
        }
    }

    IEnumerator ResultCount()
    {
        //panelLevelUp.gameObject.SetActive(true);
        
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
            NumberRewardCycle++;
            yield return new WaitForSeconds(0.075f);
        }
        for (int i = 0; i < 10; i++)
        {
            j += Random.Range(ExpReward / 100, ExpReward / 10);
            l += Random.Range(MoneyReward / 100, MoneyReward / 10);
            TextExpPanelReward.text = "" + j;
            TextMoneyPanelReward.text = "" + l;
            NumberRewardCycle++;
            yield return new WaitForSeconds(0.075f);
        }
        /*for (int i = 0; i < 10; i++)
        {
            TextExpPanelReward.text = "" + Random.Range(ExpReward / 10, ExpReward );
            TextMoneyPanelReward.text = "" + Random.Range(MoneyReward / 10, MoneyReward);
            NumberRewardCycle++;
            yield return new WaitForSeconds(0.05f);
        }*/

        TextExpPanelReward.text = "" + ExpReward;
        TextMoneyPanelReward.text = "" + MoneyReward;

        init.PlayerData.PlayerMoney += MoneyReward;
        TextValueMoney.text = "" + init.PlayerData.PlayerMoney;

        for (int i = 0; i < ExpReward - 1; i++)
        {
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

                PanelLevelUp.gameObject.SetActive(true);
                PanelLevelUpBackground.gameObject.SetActive(true);
                isLevelUp = true;
                PanelLevelUp.DOScale(new Vector3(1f, 1f, 1f), 2f);
                init.PlayerData.PlayerMoney += 500;
                TextValueMoney.text = "" + init.PlayerData.PlayerMoney;
                yield return new WaitForSeconds(2f);
            }
        } 
    }
}
