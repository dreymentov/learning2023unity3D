using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public GameObject[] gameBotObjects;
    public GameObject[] gameBotObjectsLost;

    public TMP_Text TextLost;

    public int GOlost;

    public int BotsNumber;

    public Level5Managment L5M;

    void Start()
    {
        BotsNumber = Random.Range(0, 10);

        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        L5M = FindObjectOfType<Level5Managment>();
        gameBotObjects = GameObject.FindGameObjectsWithTag("Bot");
        
        for(int i = 0; i < BotsNumber; i++)
        {
            Destroy(gameBotObjects[Random.Range(0, gameBotObjects.Length - 1)]);
        }

        StartCoroutine(CheckGO());

        StartCoroutine(BotsLost());
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerDataUIValue == null)
        {
            PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            Destroy(other.gameObject);

            StartCoroutine(CheckGO());
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerDataUIValue == null)
            {
                PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

                int j = 0;

                for (int i = 0; i < GOlost; i++)
                {
                    if (gameBotObjects[i] == null)
                    {
                        j++;
                    }
                }
                PlayerDataUIValue.PlaceInLevel = j + 1;
                StartCoroutine(EndLevelDeath());
            }

            if(PlayerDataUIValue != null)
            {
                StartCoroutine(EndLevelDeath());
            }
        }
    }

    public void WinTheLevel()
    {
        if (PlayerDataUIValue != null)
        {
            PlayerDataUIValue.PlaceInLevel = 1;
        }
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator CheckGO()
    {
        int j = 0;

        for (int i = 0; i < GOlost; i++)
        {
            if (gameBotObjectsLost[i] == null)
            {
                j++;
            }
        }

        int jj = GOlost - j;
        TextLost.text = "Оставшиеся игроки: " + jj + "/" + gameBotObjectsLost.Length;
        yield return new WaitForSeconds(2f);
        StartCoroutine(CheckGO());
        yield break;
    }

    IEnumerator BotsLost()
    {
        yield return new WaitForSeconds(0.2f);
        gameBotObjectsLost = GameObject.FindGameObjectsWithTag("Bot");

        if(L5M != null)
        {
            L5M.gameBotObjects = gameBotObjectsLost;
        }

        GOlost = gameBotObjectsLost.Length;
        TextLost.text = "Оставшиеся игроки: " + GOlost + "/" + gameBotObjectsLost.Length;

        yield break;
    }

    IEnumerator EndLevelDeath()
    {
        int j = 0;

        if ((SceneManager.GetActiveScene().name == "Level1") || (SceneManager.GetActiveScene().name == "Level5"))
        {
            StartCoroutine(CheckGO());

            for (int i = 0; i < GOlost; i++)
            {
                if (gameBotObjects[i] == null)
                {
                    j++;
                }
            }

            PlayerDataUIValue.PlaceInLevel = GOlost - j + 1;
        }
        else
        {
            j = GOlost;
            PlayerDataUIValue.PlaceInLevel = j + 1;
        }

        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Lobby");
    }
}
