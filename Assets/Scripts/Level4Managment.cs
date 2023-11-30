using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering.UI;
using UnityEditor;

public class Level4Managment : MonoBehaviour
{
    public RectTransform panelLevel;
    public RectTransform panelLevelStarted;
    public TMP_Text panelLevelText;

    public RectTransform panelMobile;

    public GameObject playerGO;
    public GameObject DeathLevel;

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
    public float ifStayedToUpgradeSpeedAgainObstacles;

    public GameObject panelWin;
    public panelWinScript panelWinScripting;

    public int BotsLost;
    public int maxObstInTheLevel4;
    public int intObs; // for enable obst in obsts

    public List<GameObject> Bots;

    // Start is called before the first frame update
    void Start()
    {
        BotsLost = 100;
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        ifStayedToUpgradeSpeedAgainObstacles = 1f;
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

        if(PlayerDataUIValue != null)
        {
            if (PlayerDataUIValue.init.PlayerData.mobile)
            {
                panelMobile.gameObject.SetActive(true);
            }
            else
            {
                panelMobile.gameObject.SetActive(false);
            }
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
        BotsLost = DeathLevel.GetComponent<DeathLevel>().BotsLostForLevel4;
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

        yield return new WaitForSeconds(2f);

        //StartCoroutine(StartedGame());
        StartCoroutine(StartedGameObstacles());
        yield break;
    }

    /*IEnumerator StartedGame()
    {
        yield return new WaitForSeconds(GameTime);
        if (PlayerDataUIValue != null)
        {
            PlayerDataUIValue.PlaceInLevel = 1;
        }
        SceneManager.LoadScene("Lobby");
        yield break;
    }*/

    IEnumerator StartedGameObstacles()
    {
        /*for(int i = 0; i < maxObstInTheLevel4; i++)
        {
            intObs = Random.Range(0, Obstacles.Length);
            StartCoroutine(InvokeObst());
            yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);
        }*/

        /*intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);

        intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);

        intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);

        intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);

        intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);

        intObs = Random.Range(0, Obstacles.Length);
        StartCoroutine(InvokeObst());
        yield return new WaitForSeconds(4.5f * ifStayedToUpgradeSpeedAgainObstacles);*/
        EnableOrDisableAgent(true);

        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        EnableOrDisableAgent(true);
        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        EnableOrDisableAgent(true);
        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        EnableOrDisableAgent(true);
        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        EnableOrDisableAgent(true);
        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        EnableOrDisableAgent(true);
        intObs = Random.Range(0, Obstacles.Length);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);

        if (FinalObstacle.active == false)
        {
            EnableOrDisableAgent(true);
            FinalObstacle.SetActive(true);
            FinalObstacle.transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
            yield return new WaitForSeconds(1f);

            FinalObstacle.transform.DOLocalMoveZ(0.75f, 8f * ifStayedToUpgradeSpeedAgainObstacles);
            yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
            EnableOrDisableAgent(false);
            yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        }

        StartCoroutine(StartObst1());
        yield return new WaitForSeconds(intervalFinalObstacles * ifStayedToUpgradeSpeedAgainObstacles);
        StartCoroutine(StartObst2());
        yield return new WaitForSeconds(intervalFinalObstacles * ifStayedToUpgradeSpeedAgainObstacles);
        StartCoroutine(StartObst3());
        yield return new WaitForSeconds(intervalFinalObstacles * ifStayedToUpgradeSpeedAgainObstacles);
        StartCoroutine(StartObst4());
        yield return new WaitForSeconds(intervalFinalObstacles * ifStayedToUpgradeSpeedAgainObstacles);
        StartCoroutine(StartObst5());
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);

        if (BotsLost > 1)
        {
            Debug.Log("SPEED UP LEVEL");
            ifStayedToUpgradeSpeedAgainObstacles *= 0.5f;
            StartCoroutine(StartedGameObstacles());
        }
        else
        {
            if (PlayerDataUIValue != null)
            {
                PlayerDataUIValue.PlaceInLevel = 1;
            }
            else
            {
                Debug.Log("Player Data null");
            }
            Debug.Log("WIN LEVEL 4");
            panelWin.GetComponent<panelWinScript>().panelWinInvoke();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Lobby");
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }

    IEnumerator StartObst1()
    {
        EnableOrDisableAgent(true);
        Obstacles1[0].SetActive(true);
        Obstacles1[0].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles1[0].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles1[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles1[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst2()
    {
        EnableOrDisableAgent(true);
        Obstacles2[0].SetActive(true);
        Obstacles2[0].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles2[0].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles2[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles2[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst3()
    {
        EnableOrDisableAgent(true);
        Obstacles3[0].SetActive(true);
        Obstacles3[0].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles3[0].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles3[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles3[0].SetActive(false);
        yield break;
    }

    IEnumerator StartObst4()
    {
        EnableOrDisableAgent(true);
        Obstacles4[0].SetActive(true);
        Obstacles4[0].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        Obstacles4[0].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles4[0].gameObject.transform.localPosition = Vector3.zero;
        Obstacles4[0].SetActive(false);
        yield break;
    }
    IEnumerator StartObst5()
    {
        EnableOrDisableAgent(true);
        Obstacles5[0].SetActive(true);
        Obstacles5[0].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);

        
        Obstacles5[0].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
        EnableOrDisableAgent(false);
        yield return new WaitForSeconds(2f * ifStayedToUpgradeSpeedAgainObstacles);
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

    /*IEnumerator InvokeObst()
    {
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(true);
        Obstacles[intObs].transform.DOLocalMoveY(12f, 0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(0.5f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.DOLocalMoveZ(1.5f, 4f * ifStayedToUpgradeSpeedAgainObstacles);
        yield return new WaitForSeconds(4f * ifStayedToUpgradeSpeedAgainObstacles);
        Obstacles[intObs].transform.localPosition = Vector3.zero;
        Obstacles[intObs].SetActive(false);
        yield break;
    }*/

    public void EnableOrDisableAgent(bool isEnOrDs)
    {
        foreach(GameObject Bot in Bots)
        {
            if(Bot != null) 
            {
                if (Bot.GetComponent<NavMeshAgent>() != null)
                {
                    Bot.GetComponent<NavMeshAgent>().enabled = isEnOrDs;
                    if(Bot.GetComponent<NavMeshAgent>().enabled == true)
                    {
                        Bot.GetComponent<NavMeshAgent>().destination = Bot.GetComponent<AI_Agent_MovingLevel4>().goals[Random.Range(0, Bot.GetComponent<AI_Agent_MovingLevel4>().goals.Length)].position;
                    }
                }
            }
        }
    }
}
