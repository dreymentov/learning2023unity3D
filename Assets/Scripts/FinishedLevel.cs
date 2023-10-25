using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishedLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public bool Finished;

    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        Finished = false;
    }


    void Update()
    {
        if (Finished)
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            gameObjectsInList.Add(other.gameObject);
        }


        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerDataUIValue == null)
            {
                PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
            }

            gameObjectsInList.Add(other.gameObject);

            for (int i = 0; i < gameObjectsInList.Count; i++)
            {
                if (gameObjectsInList[i].gameObject.CompareTag("Player"))
                {
                    PlayerDataUIValue.PlaceInLevel = i + 1;
                }
            }

            Finished = true;
        }
    }
}
