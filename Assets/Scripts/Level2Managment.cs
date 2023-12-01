using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Level2Managment : MonoBehaviour
{
    public RectTransform panelLevel;
    public TMP_Text panelLevelText;
    public RectTransform panelLevelStarted;

    public RectTransform panelMobile;

    public RectTransform panelTutorial;
    public GameObject tutorTextQuest;
    public GameObject tutorTextLost;
    public RectTransform tutorButton;

    public RectTransform panelQuest;
    public RectTransform panelLost;
    public TMP_Text TextQuest;
    public TMP_Text TextLost;

    public GameObject playerGO;

    public PlayerDataUIValue PlayerDataUIValue;

    public float SpeedMove;

    public bool FirstTime;
    public int FirstTimeIntCoroutine;

    public DeathLevel deathLevel;

    public GameObject[] bots;

    public float NativeSpeedBot;
    public float NativeSpeed;

    public GameObject panelWin;
    public panelWinScript panelWinScripting;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        deathLevel = FindObjectOfType<DeathLevel>();
        SpeedMove = playerGO.GetComponent<PlayerControlls>().speed;
        playerGO.GetComponent<PlayerControlls>().speed = 0;

        if (PlayerDataUIValue.init.PlayerData.mobile)
        {
            panelMobile.gameObject.SetActive(true);
        }
        else
        {
            panelMobile.gameObject.SetActive(false);
        }

        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;

        if(FirstTime)
        {
            FirstTimeIntCoroutine = 0;
        }

        panelTutorial.gameObject.SetActive(false);
        tutorTextQuest.gameObject.SetActive(false);
        tutorTextLost.gameObject.SetActive(false);
        tutorButton.gameObject.SetActive(false);
        TextQuest.gameObject.SetActive(false);
        TextLost.gameObject.SetActive(false);
        panelQuest.gameObject.SetActive(false);
        panelLost.gameObject.SetActive(false);

        panelLevelText.text = "3";
        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0f);
        panelLevel.gameObject.SetActive(true);
        panelLevelStarted.gameObject.SetActive(false);

        StartCoroutine(StartGameTextAndPanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGameTextAndPanel()
    {
        Color nativeColorText = panelLevelText.color;
        panelLevelText.rectTransform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        panelLevelText.text = "3";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        yield return new WaitForSeconds(0.05f);
        panelLevelText.text = "2";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        yield return new WaitForSeconds(0.05f);
        panelLevelText.text = "1";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }

        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelStarted.gameObject.SetActive(true);
        playerGO.GetComponent<PlayerControlls>().speed = SpeedMove;

        panelLevelText.text = "GO!";
        //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        panelLevelText.rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ChangeColorAlpha(panelLevelText));
        panelLevelText.rectTransform.DOMoveY(2000f, 1f);
        yield return new WaitForSeconds(0.5f);

        panelLevel.gameObject.SetActive(false);
        panelLevelText.rectTransform.DOMoveY(-2000f, 0.1f);
        panelLevelText.color = nativeColorText;

        if (FirstTime == true)
        {
            bots = deathLevel.gameBotObjectsLost;
            NativeSpeedBot = bots[0].GetComponent<NavMeshAgent>().speed;

            foreach (var bot in bots)
            {
                bot.GetComponent<NavMeshAgent>().speed = 0;
            }

            NativeSpeed = playerGO.GetComponent<PlayerControlls>().speed;
            playerGO.GetComponent<PlayerControlls>().speed = 0;

            panelTutorial.gameObject.SetActive(true);
            tutorTextQuest.gameObject.SetActive(true);
            tutorButton.gameObject.SetActive(true);
            panelQuest.gameObject.SetActive(true);
            TextQuest.gameObject.SetActive(true);

            yield break;
        }
        else
        {
            yield break;
        }
    }

    public void PressButtonStartCoroutine()
    {
        StartCoroutine(StartFirstGame());
    }

    IEnumerator StartFirstGame()
    {
        if(FirstTimeIntCoroutine == 0)
        {
            FirstTimeIntCoroutine = 1;

            tutorTextQuest.gameObject.SetActive(false);
            panelQuest.gameObject.SetActive(false);
            TextQuest.gameObject.SetActive(false);
            tutorTextLost.gameObject.SetActive(true);
            TextLost.text = deathLevel.TextLost.text;
            panelLost.gameObject.SetActive(true);
            TextLost.gameObject.SetActive(true);
            yield break;
        }

        else if (FirstTimeIntCoroutine == 1)
        {
            FirstTimeIntCoroutine = 2;

            foreach (var bot in bots)
            {
                bot.GetComponent<NavMeshAgent>().speed = NativeSpeedBot * 0.5f;
            }
            playerGO.GetComponent<PlayerControlls>().speed = NativeSpeed;

            tutorTextLost.gameObject.SetActive(false);
            panelLost.gameObject.SetActive(false);
            TextLost.gameObject.SetActive(false);

            panelTutorial.gameObject.SetActive(false);
            tutorButton.gameObject.SetActive(false);

            yield return null;
        }
        else
        {
            yield break;
        }
    }

    IEnumerator ChangeColorAlpha(TMP_Text text)
    {
        Color ColorImage = text.color;

        for (int k = 1; k < 10; k++)
        {
            ColorImage.a = 1 - (k * 0.1f);
            text.color = ColorImage;
            yield return new WaitForSeconds(0.05f);
        }

        ColorImage.a = 0;

        yield break;
    }
}
