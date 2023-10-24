using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public GameObject[] gameBotObjects;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
    }

    void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        gameBotObjects = GameObject.FindGameObjectsWithTag("Bot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            gameObjectsInList.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            gameObjectsInList.Add(other.gameObject);
            PlayerDataUIValue.PlaceInLevel = 2 - gameObjectsInList.Count + gameBotObjects.Length;
            SceneManager.LoadScene("Lobby");
        }
    }

    public void WinTheLevel()
    {
        PlayerDataUIValue.PlaceInLevel = 1;
        SceneManager.LoadScene("Lobby");
    }
}
