using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinishedLevel : MonoBehaviour
{
    public PlayerDataUIValue PlayerDataUIValue;

    public List<GameObject> gameObjectsInList;

    public bool Finished;
    public bool isInvoked;

    public TMP_Text TextLost;

    public DeathLevel DeathLevel;

    public GameObject panelFinished;
    public TMP_Text textFinished;
    public GameObject InPanelFinishedGO;

    void Start()
    {
        DeathLevel = FindObjectOfType<DeathLevel>();
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        Finished = false;
        isInvoked = false;
    }

    private void OnEnable()
    {
        gameObjectsInList.Clear();
    }

    void Update()
    {
        if (Finished)
        {
            if(isInvoked == false)
            { 
                isInvoked = true;
                StartCoroutine(FinishedAlive());
            }
        }

        /*foreach(GameObject go in gameObjectsInList)
        {
            go.gameObject.tag = "Untagged";
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            if (gameObjectsInList.Contains(other.gameObject))
            {
                return;
            }
            else
            {
                gameObjectsInList.Add(other.gameObject);
            }

            other.gameObject.tag = "Untagged";

            int j = gameObjectsInList.Count;
            int jj = DeathLevel.gameBotObjectsLost.Length + 1 - j;
            int jjj = DeathLevel.gameBotObjectsLost.Length + 1;
            TextLost.text = "ŒÒÚ‡‚¯ËÂÒˇ Ë„ÓÍË: " + jj + "/" + jjj;
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            gameObjectsInList.Add(other.gameObject);

            for (int i = 0; i < gameObjectsInList.Count; i++)
            {
                if (gameObjectsInList[i].gameObject.CompareTag("Player"))
                {
                    if (PlayerDataUIValue == null)
                    {
                        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();

                        if(PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay == true)
                        {
                            Init init = PlayerDataUIValue.init;
                            init.PlayerData.PlayerFirstTimeNeedShop = true;

                            Debug.Log("œŒœ€“ ¿ »«Ã≈Õ»“‹ Õ¿ »—“»Õ”");
                            Debug.Log(init.PlayerData.PlayerFirstTimeNeedShop);

                            PlayerDataUIValue.PlaceInLevel = i + 1;
                        }
                        else
                        {
                            PlayerDataUIValue.PlaceInLevel = i + 1;
                        }
                    }
                    else
                    {
                        if (PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay == true)
                        {
                            Init init = PlayerDataUIValue.init;
                            init.PlayerData.PlayerFirstTimeNeedShop = true;

                            Debug.Log("œŒœ€“ ¿ »«Ã≈Õ»“‹ Õ¿ »—“»Õ”");
                            Debug.Log(init.PlayerData.PlayerFirstTimeNeedShop);

                            PlayerDataUIValue.PlaceInLevel = i + 1;
                        }
                        else
                        {
                            PlayerDataUIValue.PlaceInLevel = i + 1;
                        }
                    }

                    Finished = true;
                }
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator FinishedAlive()
    {
        DeathLevel.panelWinInDeathlevel.GetComponent<panelWinScript>().panelWinInvoke();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Lobby");
        yield break;
    }
}
