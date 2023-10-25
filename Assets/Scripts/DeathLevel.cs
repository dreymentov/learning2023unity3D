using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public GameObject[] gameBotObjects;

    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        gameBotObjects = GameObject.FindGameObjectsWithTag("Bot");
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
            gameObjectsInList.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerDataUIValue == null)
            {
                PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
            }

            gameObjectsInList.Add(other.gameObject);
            if(PlayerDataUIValue != null)
            {
                PlayerDataUIValue.PlaceInLevel = 2 - gameObjectsInList.Count + gameBotObjects.Length;
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
}
