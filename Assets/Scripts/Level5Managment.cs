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

    public List<GameObject> CubeListLevel5;

    public GameObject[] CubeTVColor;
    public GameObject[] CubeTVText;

    public Color NativeColor;
    public List<Color> ColorList;

    [Header("Time wait to paint")]

    public float _Color;
    public float _ColorStartGame;
    public float _ColorDisableCubes;
    public float _ColorEnableCubes;

    [Header("Bots Setting")]

    public GameObject[] gameBotObjects;
    public GameObject[] gameBotObjects1;
    public GameObject[] gameBotObjects2;

    public GameObject panelWin;
    public panelWinScript panelWinScripting;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

        SpeedMove = playerGO.GetComponent<PlayerControlls>().speed;
        playerGO.GetComponent<PlayerControlls>().speed = 0;


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

        panelLevelText.text = "3";
        panelLevelText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0f);
        panelLevel.gameObject.SetActive(true);
        panelLevelStarted.gameObject.SetActive(false);

        NativeColor = CubeListLevel5[0].gameObject.GetComponent<Renderer>().material.color;

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

        yield return new WaitForSeconds(2f);

        StartCoroutine(Level5());

        yield break;
    }

    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }

    IEnumerator Level5()
    {
        StartCoroutine(Level5_1());

        yield break;
    }

    IEnumerator Level5_1()
    {
        Shuffle(ColorList);
        Shuffle(CubeListLevel5);

        foreach (var bot in gameBotObjects)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = true;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }
        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }
        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }
        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_ColorStartGame);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        foreach (var bot in gameBotObjects)
        {
            if (bot != null)
            {
                int i = Random.Range(0, 100);
                if (i > 80)
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, 3)].transform.position;
                }
                else
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
                }
            }
        }

        StartCoroutine(TextTV());

        yield return new WaitForSeconds(_ColorDisableCubes);

        foreach (var bot in gameBotObjects)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = false;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
            CubeListLevel5[i].gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(_ColorEnableCubes);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Level5_2());

        yield break;
    }


    IEnumerator Level5_2()
    {
        StartCoroutine(BotsCheck_1());

        yield return new WaitForSeconds(_Color);

        Shuffle(ColorList);
        Shuffle(CubeListLevel5);

        foreach (var bot in gameBotObjects1)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = true;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects1)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects1)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects1)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects1)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }
        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }
        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }
        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects1)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_ColorStartGame);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        foreach (var bot in gameBotObjects1)
        {
            if (bot != null)
            {
                int i = Random.Range(0, 100);
                if (i > 80)
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, 3)].transform.position;
                }
                else
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
                }
            }
        }

        StartCoroutine(TextTV());

        yield return new WaitForSeconds(_ColorDisableCubes);

        foreach (var bot in gameBotObjects1)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = false;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
            CubeListLevel5[i].gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(_ColorEnableCubes);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(Level5_3());

        yield break;
    }

    IEnumerator Level5_3()
    {
        StartCoroutine(BotsCheck_2());

        yield return new WaitForSeconds(_Color);

        Shuffle(ColorList);
        Shuffle(CubeListLevel5);

        foreach (var bot in gameBotObjects2)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = true;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects2)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects2)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects2)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        foreach (var bot in gameBotObjects2)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_Color);

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }
        for (int i = 4; i < 8; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[1];
        }
        for (int i = 8; i < 12; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[2];
        }
        for (int i = 12; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[3];
        }

        yield return new WaitForSeconds(_Color);

        foreach (var bot in gameBotObjects2)
        {
            bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
        }

        for (int i = 0; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        yield return new WaitForSeconds(_ColorStartGame);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        foreach (var bot in gameBotObjects2)
        {
            if (bot != null)
            {
                int i = Random.Range(0, 100);
                if (i > 80)
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, 3)].transform.position;
                }
                else
                {
                    bot.GetComponent<NavMeshAgent>().destination = CubeListLevel5[Random.Range(0, CubeListLevel5.Count)].transform.position;
                }
            }
        }

        StartCoroutine(TextTV());

        yield return new WaitForSeconds(_ColorDisableCubes);

        foreach (var bot in gameBotObjects2)
        {
            if (bot != null)
            {
                bot.GetComponent<NavMeshAgent>().enabled = false;
                bot.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = ColorList[0];
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
            CubeListLevel5[i].gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(_ColorEnableCubes);

        foreach (var cubes in CubeTVColor)
        {
            cubes.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        for (int i = 0; i < 4; i++)
        {
            CubeListLevel5[i].gameObject.GetComponent<Renderer>().material.color = NativeColor;
        }

        for (int i = 4; i < 16; i++)
        {
            CubeListLevel5[i].gameObject.SetActive(true);
        }

        foreach (var bot in gameBotObjects2)
        {
            if (bot != null)
            {
                bot.gameObject.tag = "Untagged";
            }
        }

        panelWin.GetComponent<panelWinScript>().panelWinInvoke();

        yield return new WaitForSeconds(3f);

        PlayerDataUIValue.PlaceInLevel = 1;
        SceneManager.LoadScene("Lobby");
        yield break;
    }

    IEnumerator TextTV()
    {
        foreach(var text in CubeTVText)
        {
            text.gameObject.SetActive(true);
            text.gameObject.GetComponent<TextMesh>().text = "3";
        }

        yield return new WaitForSeconds(_ColorDisableCubes * 0.25f);

        foreach (var text in CubeTVText)
        {
            text.gameObject.GetComponent<TextMesh>().text = "2";
        }

        yield return new WaitForSeconds(_ColorDisableCubes * 0.25f);

        foreach (var text in CubeTVText)
        {
            text.gameObject.GetComponent<TextMesh>().text = "1";
        }

        yield return new WaitForSeconds(_ColorDisableCubes * 0.25f);

        foreach (var text in CubeTVText)
        {
            text.gameObject.SetActive(false);
            text.gameObject.GetComponent<TextMesh>().text = "3";
        }

        yield return new WaitForSeconds(_ColorDisableCubes * 0.25f);

        yield break;
    }

    IEnumerator BotsCheck_1()
    {
        yield return new WaitForSeconds(0.2f);
        gameBotObjects1 = GameObject.FindGameObjectsWithTag("Bot");
        yield break;
    }

    IEnumerator BotsCheck_2()
    {
        yield return new WaitForSeconds(0.2f);
        gameBotObjects2 = GameObject.FindGameObjectsWithTag("Bot");
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