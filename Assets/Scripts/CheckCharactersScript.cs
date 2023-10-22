using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharactersScript : MonoBehaviour
{
    public GameObject[] goCharacters;

    public int goId;

    private void Awake()
    {
        foreach(var character in goCharacters)
        {
            character.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        goId = Random.Range(0, goCharacters.Length);
        goCharacters[goId].SetActive(true);
    }

    public void ClickNextCharacter()
    {
        goCharacters[goId].SetActive(false);

        if(goId == goCharacters.Length - 1)
        {
            goId = 0;
        }
        else
        {
            goId++;
        }

        goCharacters[goId].SetActive(true);
    }

    public void ClickPreviousCharacter()
    {
        goCharacters[goId].SetActive(false);

        if (goId == 0)
        {
            goId = goCharacters.Length - 1;
        }
        else
        {
            goId--;
        }

        goCharacters[goId].SetActive(true);
    }

    public void ClickRandomCharacter()
    {
        goCharacters[goId].SetActive(false);
        goId = Random.Range(0, goCharacters.Length);
        goCharacters[goId].SetActive(true);
    }
}
