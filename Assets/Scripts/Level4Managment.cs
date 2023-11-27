using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Level4Managment : MonoBehaviour
{
    public RectTransform panelLevel;
    public RectTransform panelLevelStarted;
    public TMP_Text panelLevelText;

    public RectTransform panelMobile;

    public GameObject playerGO;

    public PlayerDataUIValue PlayerDataUIValue;

    public float SpeedMove;

    public float GameTime;

    public GameObject FinalObstacle;
    public GameObject[] Obstacles;
    public GameObject[] Obstacles1;
    public GameObject[] Obstacles2;
    public GameObject[] Obstacles3;
    public GameObject[] Obstacles4;
    public GameObject[] Obstacles5;

    public float intervalFinalObstacles;

    public GameObject panelWin;
    public panelWinScript panelWinScripting;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

        SpeedMove = playerGO.GetComponent<PlayerControlls>().speed;
        playerGO.GetComponent<PlayerControlls>().speed = 0;

        FinalObstacle.SetActive(false);

        foreach (var obstacle in Obstacles)
        {
            obstacle.SetActive(false);
        }
        foreach (var obstacle in Obstacles1)
        {
            obstacle.SetActive(false);
        }
        foreach (var obstacle in Obstacles2)
        {
            obstacle.SetActive(false);
        }
        foreach (var obstacle in Obstacles3)
        {
            obstacle.SetActive(false);
        }
        foreach (var obstacle in Obstacles4)
        {
            obstacle.SetActive(false);
        }
        foreach (var obstacle in Obstacles5)
        {
            obstacle.SetActive(false);
        }

        if (PlayerDataUIValue.init.PlayerData.mobile)
        {
            panelMobile.gameObject.SetActive(true);
        }
        else
        {
            panelMobile.gameObject.SetActive(false);
        }

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

        panelLevelText.text = "3";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f);
        panelLevelText.text = "2";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            //panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f);
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

        StartCoroutine(StartedGame());
        StartCoroutine(StartedGameObstacles());
        yield break;
    }

    IEnumerator StartedGame()
    {
        yield return new WaitForSeconds(GameTime);
        if (PlayerDataUIValue != null)
        {
            PlayerDataUIValue.PlaceInLevel = 1;
        }
        SceneManager.LoadScene("Lobby");
        yield break;
    }

    IEnumerator StartedGameObstacles()
    {
        Obstacles[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[0].SetActive(false);

        Obstacles[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[1].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[1].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[1].SetActive(false);

        Obstacles[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[2].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[2].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[2].SetActive(false);

        Obstacles[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[3].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[3].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[3].SetActive(false);

        Obstacles[4].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[4].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[4].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[4].SetActive(false);

        Obstacles[5].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[5].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[5].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[5].SetActive(false);

        Obstacles[6].SetActive(true);
        yield return new WaitForSeconds(1f);
        Obstacles[6].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles[6].gameObject.transform.localPosition = Vector3.zero;
        Obstacles[6].SetActive(false);

        FinalObstacle.SetActive(true);
        yield return new WaitForSeconds(1f);
        FinalObstacle.transform.DOLocalMoveZ(0.75f, 10f);
        yield return new WaitForSeconds(10f);

        StartCoroutine(StartObst1());
        yield return new WaitForSeconds(intervalFinalObstacles);
        StartCoroutine(StartObst2());
        yield return new WaitForSeconds(intervalFinalObstacles);
        StartCoroutine(StartObst3());
        yield return new WaitForSeconds(intervalFinalObstacles);
        StartCoroutine(StartObst4());
        yield return new WaitForSeconds(intervalFinalObstacles);
        StartCoroutine(StartObst5());
        yield return new WaitForSeconds(2f);
        panelWin.GetComponent<panelWinScript>().panelWinInvoke();
        yield return new WaitForSeconds(2f);
        if (PlayerDataUIValue != null)
        {
            PlayerDataUIValue.PlaceInLevel = 1;
        }
        SceneManager.LoadScene("Lobby");

        yield break;
    }

    IEnumerator StartObst1()
    {
        Obstacles1[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Obstacles1[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles1[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles1[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst2()
    {
        Obstacles2[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Obstacles2[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles2[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles2[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst3()
    {
        Obstacles3[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Obstacles3[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles3[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles3[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst4()
    {
        Obstacles4[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Obstacles4[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles4[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles4[0].SetActive(false);
        yield break;
    }
    IEnumerator StartObst5()
    {
        Obstacles5[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Obstacles5[0].transform.DOLocalMoveZ(1.5f, 4f);
        yield return new WaitForSeconds(4f);
        Obstacles5[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles5[0].SetActive(false);
        yield break;
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
