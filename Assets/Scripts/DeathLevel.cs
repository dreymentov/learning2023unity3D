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

    void Start()
    {
        BotsNumber = Random.Range(0, 10);

        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        gameBotObjects = GameObject.FindGameObjectsWithTag("Bot");
        
        for(int i = 0; i < BotsNumber; i++)
        {
            Destroy(gameBotObjects[Random.Range(0, gameBotObjects.Length - 1)]);
        }

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
            }

            if(PlayerDataUIValue != null)
            {
                int j = 0;

                for (int i = 0; i < GOlost; i++)
                {
                    if (gameBotObjects[i] == null)
                    {
                        j++;
                    }
                }

                PlayerDataUIValue.PlaceInLevel = 4 - j;
            }
            SceneManager.LoadScene("Lobby");
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

        yield break;
    }

    IEnumerator BotsLost()
    {
        yield return new WaitForSeconds(1.5f);
        gameBotObjectsLost = GameObject.FindGameObjectsWithTag("Bot");

        GOlost = gameBotObjectsLost.Length;
        TextLost.text = "Оставшиеся игроки: " + GOlost + "/" + gameBotObjectsLost.Length;

        yield break;
    }
}
