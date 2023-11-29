using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject CheckChar;
    public GameObject CanvasMain;
    public GameObject ThisCharacter;
    public CheckCharactersScript CCharScript;
    public Init CMainInit;
    public void Start()
    {
        CCharScript = CheckChar.GetComponent<CheckCharactersScript>();
        CMainInit = CanvasMain.GetComponent<Init>();
    }

    public void StartBuy()
    {

    }

    public void OnEnable()
    {
        CanvasMain = FindObjectOfType<Init>().gameObject;
        CMainInit = CanvasMain.GetComponent<Init>();
    }

    public void OnDisable()
    {
        
    }
}
