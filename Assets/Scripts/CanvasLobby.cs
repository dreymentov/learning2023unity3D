using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasLobby : MonoBehaviour
{
    public RectTransform ButtonPr;
    public RectTransform ButtonNe;
    public RectTransform ButtonRa;
    public RectTransform ButtonStart;
    public RectTransform ButtonMenu;

    public GameObject MainCanvas;

    public TMP_Text PlaceText;

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var InvokerMethod = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        InvokerMethod.isLevelUp = false;
        PlaceText.text = "Место: " + InvokerMethod.PlaceInLevel;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
