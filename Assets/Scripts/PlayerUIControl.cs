using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class PlayerUIControl : MonoBehaviour
{
    public Transform panel;
    public Transform MainImagesMover;

    public Image[] imagesList;
    public Image[] imagesList1;

    public Image imageCenterInPanel;
    public Image imageCenterImageInPanel;

    public float border_X;
    public float border_X1;
    public float _cycleLength = 0.1f;
    public float speedMove = 100f;
    public float waitTimer = 2f;

    public bool isActivacted;
    public bool isPressed = false;
    public bool isStop = false;

    public PlayerData playerData;
    public PlayerDataUIValue PlayerDataUIValue;

    public GameObject ImageTextFirstGame;
    public bool FirstTime;
    public bool FirstTimeNeedShop;

    public void Start()
    {
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;
        FirstTimeNeedShop = PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop;

        if (FirstTime == true)
        {
            ImageTextFirstGame.gameObject.SetActive(true);
        }
        else
        {
            ImageTextFirstGame.gameObject.SetActive(false);
        }

        isPressed = false;
        isStop = false;
    }
    public void StartGameImage()
    {
        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;
        FirstTimeNeedShop = PlayerDataUIValue.init.PlayerData.PlayerFirstTimeNeedShop;

        if ((FirstTime == true) && (FirstTimeNeedShop == true))
        {
            return;
        }
        else
        {
            isPressed = true;

            panel.gameObject.SetActive(true);

            isActivacted = false;

            /*foreach (var image in imagesList)
            {
                image.color = Random.ColorHSV();
            }
            foreach (var image in imagesList1)
            {
                image.color = Random.ColorHSV();
            }*/

            StartCoroutine(ImageMoveStart(MainImagesMover));
            StartCoroutine(ChangeImageLevel());
            StartCoroutine(WaitAwakeGame());
        }
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if(MainImagesMover.localPosition.x >= 2000)
        {
            StopCoroutine(ImageMoveStart(MainImagesMover));
            StopCoroutine(ImageMove(MainImagesMover));
            StartCoroutine(ImageMove(MainImagesMover));
            
        }
        else
        {
            return;
        }
    }

    IEnumerator ImageMoveStart(Transform imageTransform)
    {
        imageTransform.localPosition = new Vector3(0, imageTransform.localPosition.y, imageTransform.localPosition.z);
        imageTransform.transform.DOMoveX(imageTransform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    IEnumerator ImageMove(Transform imageTransform)
    {
        DOTween.Kill(imageTransform.transform);
        imageTransform.localPosition = new Vector3(0, imageTransform.localPosition.y, imageTransform.localPosition.z);
        imageTransform.transform.DOMoveX(imageTransform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    IEnumerator AwakeGame()
    {
        string Level;
        int ii = Random.Range(0, 150);
        int imageLevel = 0;

        if (ii > 120)
        {
            Level = "Level1";
            imageLevel = 0;
        }
        else if(ii > 90 && ii <= 120)
        {
            Level = "Level2";
            imageLevel = 1;
        }
        else if (ii > 60 && ii <= 90)
        {
            Level = "Level3";
            imageLevel = 2;
        }
        else if (ii > 30 && ii <= 60)
        {
            Level = "Level4";
            imageLevel = 3;
        }
        else
        {
            Level = "Level5";
            imageLevel = 4;
        }

        isStop = true;
        StopCoroutine(ChangeImageLevel());
        isPressed = false;

        StopCoroutine(ImageMove(MainImagesMover));

        DOTween.Kill(MainImagesMover.transform);

        if(FirstTime == true)
        {
            Sprite sprite = imagesList1[1].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        }
        else
        {
            Sprite sprite = imagesList1[imageLevel].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
        }
        yield return new WaitForSeconds(1.5f);

        panel.gameObject.SetActive(false);

        FirstTime = PlayerDataUIValue.init.PlayerData.PlayerFirstTimePlay;

        if (FirstTime == true)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene(Level);
        }

        //SceneManager.LoadScene("Level2");

        yield return null;
    }

    IEnumerator WaitAwakeGame()
    {
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine(AwakeGame());
        yield return null;
    }

    IEnumerator ChangeImageLevel()
    {
        if(isStop == false)
        {
            Sprite sprite = imagesList1[Random.Range(0, imagesList1.Length)].GetComponent<Image>().sprite;
            imageCenterImageInPanel.GetComponent<Image>().sprite = sprite;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ChangeImageLevel());
        }
        else
        {
            yield break;
        }
        
    }
}
