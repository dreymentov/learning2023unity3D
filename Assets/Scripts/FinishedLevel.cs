using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinishedLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public bool Finished;

    public TMP_Text TextLost;

    public DeathLevel DeathLevel;

    void Start()
    {
        DeathLevel = FindObjectOfType<DeathLevel>();
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        Finished = false;
    }

    private void OnEnable()
    {
        gameObjectsInList.Clear();
    }

    void Update()
    {
        if (Finished)
        {
            SceneManager.LoadScene("Lobby");
        }

        /*foreach(GameObject go in gameObjectsInList)
        {
            go.gameObject.tag = "Untagged";
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            if (gameObjectsInList.Contains(other.gameObject))
            {
                return;
            }
            else
            {
                gameObjectsInList.Add(other.gameObject);
            }

            other.gameObject.tag = "Untagged";

            int j = gameObjectsInList.Count;
            int jj = DeathLevel.gameBotObjectsLost.Length - j;
            TextLost.text = "Оставшиеся игроки: " + jj + "/" + DeathLevel.gameBotObjectsLost.Length;
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            gameObjectsInList.Add(other.gameObject);

            for (int i = 0; i < gameObjectsInList.Count; i++)
            {
                if (gameObjectsInList[i].gameObject.CompareTag("Player"))
                {
                    if (PlayerDataUIValue == null)
                    {
                        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
                        PlayerDataUIValue.PlaceInLevel = i + 1;
                    }
                    else
                    {
                        PlayerDataUIValue.PlaceInLevel = i + 1;
                    }

                    Finished = true;
                }
            }
        }
        else
        {
            return;
        }
    }
}
