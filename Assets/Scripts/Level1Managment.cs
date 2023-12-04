using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Level1Managment : MonoBehaviour
{
    public List<GameObject> cubes;
    public List<GameObject> cubesCheck;
    public List<GameObject> cubesObst;

    public GameObject playerGO;
    
    public GameObject[] Obstacles;

    public DeathLevel DeathLevel;

    public PlayerDataUIValue PlayerDataUIValue;

    public int[] cyclingLifeCubes;

    public float shakerDuration = 0.5f;
    public float shakerStrenght = 0.5f;
    public float moveCycleLength = 2f;
    public float speedMove = -1f;
    public float waitTimer;
    public float waitTimerObs;
    public float minPowerObs = -64;
    public float maxPowerObs = 64;

    public float powerObs;

    public int cubNumberCrushing = 0;
    public int minTimerObs = 3;
    public int maxTimerObs = 6;
    public int rowObstacle = 0;

    public bool startedStop;
    public bool isStartGame;
    public bool isCrashingPlace;
    public bool isFinishedLevel1;

    public float SpeedMove;

    public RectTransform panelLevel;
    public RectTransform panelLevelStarted;
    public TMP_Text panelLevelText;

    public RectTransform panelMobile;

    public GameObject panelWin;
    public panelWinScript panelWinScripting;
    void Start()
    {
        SpeedMove = playerGO.GetComponent<PlayerControlls>().speed;
        playerGO.GetComponent<PlayerControlls>().speed = 0;

        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

        DeathLevel = FindObjectOfType<DeathLevel>();
        cyclingLifeCubes = new int[cubes.Count];

        for (int i = 0; i < cyclingLifeCubes.Length; i++)
        {
            cyclingLifeCubes[i] = 0;
        }

        foreach (var cubObs in cubesObst)
        {
            cubObs.GetComponent<NavMeshObstacle>().enabled = false;
        }

        rowObstacle = 0;

        startedStop = false;
        isStartGame = true;
        isCrashingPlace = false;

        if (PlayerDataUIValue != null)
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
            Debug.Log("No Have Player Data");
        }
        

        panelLevelText.text = "3";
        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0f);
        panelLevel.gameObject.SetActive(true);
        panelLevelStarted.gameObject.SetActive(false);


        StartCoroutine(StartGameTextAndPanel());
        StartCoroutine(startGame());
        StartCoroutine(startGameObs());
    }

    private void FixedUpdate()
    {
        if ((cubNumberCrushing > 6) && (startedStop == false))
        {
            startedStop = true;

            StopAllCoroutines();
            StartCoroutine(StopObs());
        }
    }

    IEnumerator ShakeCube(int number)
    {
        var cubTf = cubes[number].transform;

        if (cubes.Count == 1)
        {
            StopCoroutine(ShakeCube(number));
            StartCoroutine(StopObs());
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 0)
        {
            isCrashingPlace = false; 

            for (int i = 0; i < cubesCheck.Count; i++)
            {
                if (cubesCheck[i] == cubes[number].gameObject)
                {
                    cubesCheck[i] = null;
                }
            }
            Invoke("ActiveObj", 0f);
            cubes[number].gameObject.GetComponent<Renderer>().material.color = Color.green;
            cubTf.DOShakePosition(shakerDuration, shakerStrenght).SetLoops(-1, LoopType.Restart).SetTarget(cubTf);
            cubTf.DOShakeRotation(shakerDuration, shakerStrenght).SetLoops(-1, LoopType.Restart).SetTarget(cubTf);
            //cubTf.DOShakeScale(shakerDuration, shakerStrenght).SetLoops(-1,LoopType.Restart).SetTarget(cubTf);
            cyclingLifeCubes[cubNumberCrushing]++;
            yield return new WaitForSeconds(5f);
            StartCoroutine(ShakeCube(number));
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 1)
        {
            isCrashingPlace = true;
            cubes[number].gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            DOTween.Kill(cubTf);
            cubTf.DOMoveY(speedMove, moveCycleLength).SetTarget(cubTf);
            cyclingLifeCubes[cubNumberCrushing]++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(ShakeCube(number));
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 2)
        {
            DOTween.Kill(cubTf);
            Destroy(cubes[number]);
            cubes.RemoveAt(number);
            cubNumberCrushing++;
            StartCoroutine(ShakeCube(Random.Range(0, cubes.Count)));
        }
        else
        {
            yield break;
        }
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(waitTimer + 1);
        StartCoroutine(ShakeCube(Random.Range(0, cubes.Count)));
    }
    IEnumerator startGameObs()
    {
        yield return new WaitForSeconds(waitTimer);

        Obstacles[0].GetComponent<Obsctacles>().powerObstacl = powerObs;
        Obstacles[1].GetComponent<Obsctacles>().powerObstacl = -powerObs;

        StartCoroutine(randomPowerValue());
    }

    IEnumerator randomPowerValue()
    {
        var waitTimerObs = 4f; //Random.Range(minTimerObs, maxTimerObs);
        //powerObs = Random.Range(minPowerObs, maxPowerObs);
        //Obstacles[rowObstacle].GetComponent<Obsctacles>().powerObstacl = powerObs;
        Obstacles[0].GetComponent<Obsctacles>().powerObstacl *= 1.1f;
        Obstacles[1].GetComponent<Obsctacles>().powerObstacl *= 1.1f;
        yield return new WaitForSeconds(waitTimerObs);
        StartCoroutine(randomPowerValue());
    }

    IEnumerator StopObs()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        PlayerDataUIValue.PlaceInLevel = 1;
        Obstacles[0].GetComponent<Obsctacles>().powerObstacl = 0;
        Obstacles[1].GetComponent<Obsctacles>().powerObstacl = 0;
        panelLevel.GetComponent<panelWinScript>().panelWinInvoke();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Lobby");
        yield break;
    }

    public void ActiveObj()
    {
        for(int i = 0; i < cubesObst.Count; i++)
        {
            if (cubesCheck[i] == null)
            {
                //cubesObst[i].GetComponent<NavMeshObstacle>().enabled = true;
            }
        }
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
