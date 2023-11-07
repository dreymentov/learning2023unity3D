using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopCharacter : MonoBehaviour
{
    public bool isBuyOrNot = false;
    public GameObject Bought;
    public GameObject Cost;
    public GameObject MainCanvas;
    public GameObject CheckChar;
    public GameObject ButtonBuy;
    public CheckCharactersScript CCharGet;
    public PlayerDataUIValue MCanvas;
    public int CostForBuy = 10;
    public int CharId = 29;

    // Start is called before the first frame update
    void Start()
    {
        MainCanvas = FindObjectOfType<Init>().gameObject;
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ButtonBuy.SetActive(false);
        CCharGet = CheckChar.GetComponent<CheckCharactersScript>();
        MCanvas = MainCanvas.gameObject.GetComponent<PlayerDataUIValue>();
        isBuyOrNot = MCanvas.init.PlayerData.PlayerCharId[CharId];
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void BuyCharacter()
    {
        CCharGet.goCharacters[CCharGet.goId].SetActive(false);
        CCharGet.goId = CharId;
        CCharGet.goCharacters[CharId].SetActive(true);
        if( isBuyOrNot == false)
        {
            ButtonBuy.SetActive(true);
            ButtonBuy.GetComponent<BuyButton>().ThisCharacter = this.gameObject;
        }
        else
        {
            ButtonBuy.SetActive(false);
        }
    }
}
