using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCharactersScript : MonoBehaviour
{
    public GameObject MainCanvas;

    public void Start()
    {
        
    }

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var InvokerMethod = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        InvokerMethod.isLevelUp = false;
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            InvokerMethod.StartCoroutine(InvokerMethod.InvokeStartThisObject());
        }
        else return;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
