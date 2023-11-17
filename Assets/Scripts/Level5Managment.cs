using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Level5Managment : MonoBehaviour
{
    public RectTransform panelLevel;
    public RectTransform panelLevelStarted;
    public TMP_Text panelLevelText;

    public RectTransform panelMobile;

    public GameObject playerGO;

    public PlayerDataUIValue PlayerDataUIValue;

    public float SpeedMove;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

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
        panelLevelText.text = "3";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f);
        panelLevelText.text = "2";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        yield return new WaitForSeconds(0.3f);

        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.1f);
        panelLevelText.text = "1";
        for (int i = 0; i < 10; i++)
        {
            panelLevelText.rectTransform.DOScale(new Vector3(0.1f * i, 0.1f * i, 0.1f * i), 0.1f);
            panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0 + 36 * i), 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        panelLevelText.text = "GO!";
        panelLevelText.rectTransform.DORotate(new Vector3(0, 0, 0), 0.1f);
        panelLevelText.rectTransform.DOScale(new Vector3(1, 1, 1), 0.5f);
        yield return new WaitForSeconds(0.6f);

        panelLevel.gameObject.SetActive(false);
        panelLevelStarted.gameObject.SetActive(true);
        playerGO.GetComponent<PlayerControlls>().speed = SpeedMove;
        yield break;
    }
}
