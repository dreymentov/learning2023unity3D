using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopCharacter : MonoBehaviour
{
    public GameObject Bought;
    public GameObject Cost;
    public GameObject MainCanvas;
    public GameObject ButtonBuy;

    public PlayerDataUIValue MCanvas;

    public int CostForBuy = 999;
    public int ItemId = 999;

    public bool isBuyOrNot = false;

    // Start is called before the first frame update
    void Start()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        Cost.GetComponent<TMP_Text>().text = "" + CostForBuy;
        ButtonBuy.SetActive(false);

        if ( isBuyOrNot == false)
        {
            Bought.SetActive(false);
            Cost.SetActive(true);
        }
        else
        {
            Bought.SetActive(true);
            Cost.SetActive(false);
        }


    }

    private void OnEnable()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ButtonBuy.SetActive(false);
        
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void BuyCharacter()
    {
        if( isBuyOrNot == false)
        {
            ButtonBuy.SetActive(true);
        }
        else
        {
            ButtonBuy.SetActive(false);
        }
    }
}
