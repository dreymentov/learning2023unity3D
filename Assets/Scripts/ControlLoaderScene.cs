using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLoaderScene : MonoBehaviour
{
    public void StartGameScene()
    {
        string Level;
        int ii = Random.Range(0, 100);
        if(ii > 50)
        {
            Level = "Level1";
        }
        else
        {
            Level = "Level2";
        }
        SceneManager.LoadScene(Level);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
