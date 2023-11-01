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

    public Image[] imagesList;

    public Vector2[] PosTf;

    public Image imageCenterInPanel;
    public Image imageCheckerLeft;
    public Image imageCheckerRight;

    public float border_X;
    public float border_X1;
    public float _cycleLength = 0.1f;
    public float speedMove = 100f;
    public float waitTimer = 2f;

    public bool isActivacted;
    public bool isPressed = false;


    public void Start()
    {
        PosTf = new Vector2[imagesList.Length];
        for(int i = 0; i < imagesList.Length; i++)
        {
            PosTf[i] = imagesList[i].transform.position;
        }
        isPressed = false;
    }
    public void StartGameImage()
    {
        isPressed = true;

        panel.gameObject.SetActive(true);

        border_X = imageCheckerLeft.transform.localPosition.x;
        border_X1 = imageCheckerRight.transform.localPosition.x;

        isActivacted = false;

        foreach(var image in imagesList)
        {
            image.color = Random.ColorHSV();
        }

        foreach(var imageTransformStart in imagesList)
        {
            StartCoroutine(ImageMoveStart(imageTransformStart));
        }
        StartCoroutine(WaitAwakeGame());
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if ((isActivacted == false) && (isPressed == true))
        {
            foreach (var imageTransform in imagesList)
            {
                if (imageTransform.transform.localPosition.x >= border_X1)
                {
                    if (ImageMoveStart(imageTransform) != null)
                    {
                        StopCoroutine(ImageMoveStart(imageTransform));
                        StartCoroutine(ImageMove(imageTransform));
                    }
                    else
                    {
                        StopCoroutine(ImageMove(imageTransform));
                        StartCoroutine(ImageMoveStart(imageTransform));
                    }
                }
            }
        }
    }

    IEnumerator ImageMoveStart(Image imageTransform)
    {
        imageTransform.transform.DOMoveX(imageTransform.transform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    IEnumerator ImageMove(Image imageTransform)
    {
        DOTween.Kill(imageTransform.transform);
        imageCenterInPanel.color = imageTransform.color;
        imageTransform.transform.localPosition = new Vector3(border_X, 0, 0);
        imageTransform.transform.DOMoveX(imageTransform.transform.position.x + speedMove, _cycleLength).SetLoops(-1, LoopType.Incremental).SetTarget(imageTransform.transform);
        yield return null;
    }

    IEnumerator AwakeGame()
    {
        panel.gameObject.SetActive(false);
        isPressed = false;
        string Level;
        int ii = Random.Range(0, 100);

        if (ii > 65)
        {
            Level = "Level1";
        }
        else if(ii > 32 && ii <= 65)
        {
            Level = "Level2";
        }
        else
        {
            Level = "Level3";
        }
        isPressed = false;
        StopAllCoroutines();
        foreach (var imageTransform in imagesList)
        {
            int i = 0;
            DOTween.Kill(imageTransform.transform);
            imageTransform.transform.position = imagesList[i].transform.position;
            i++;
        }
        SceneManager.LoadScene(Level);
        yield return null;
    }

    IEnumerator WaitAwakeGame()
    {
        yield return new WaitForSeconds(waitTimer);
        isPressed = false;
        StartCoroutine(AwakeGame());
    }
}
