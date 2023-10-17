using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUIControl : MonoBehaviour
{
    public List<NavMeshAgent> agentsList;

    public Transform panel;

    public Image[] imagesList;

    public Image imageCenterInPanel;
    public Image imageCheckerLeft;
    public Image imageCheckerRight;

    public float border_X;
    public float border_X1;
    public float _cycleLength = 0.1f;
    public float speedMove = 100f;
    public float waitTimer = 2f;

    public bool isActivacted;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        border_X = imageCheckerLeft.transform.localPosition.x;
        border_X1 = imageCheckerRight.transform.localPosition.x;

        isActivacted = false;

        foreach(var image in imagesList)
        {
            image.color = Random.ColorHSV();
        }

        foreach(var imageTransformStart in imagesList)
        {
            coroutine = ImageMoveStart(imageTransformStart);
            StartCoroutine(coroutine);
        }

        coroutine = WaitAwakeGame();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivacted == false)
        {
            foreach (var imageTransform in imagesList)
            {
                if (imageTransform.transform.localPosition.x >= border_X1)
                {
                    if (ImageMoveStart(imageTransform) != null)
                    {
                        coroutine = ImageMoveStart(imageTransform);
                        StopCoroutine(coroutine);

                        coroutine = ImageMove(imageTransform);
                        StartCoroutine(coroutine);
                    }
                    else
                    {
                        coroutine = ImageMove(imageTransform);
                        StopCoroutine(coroutine);
                        StartCoroutine(coroutine);
                    }
                }
            }


        }

        if (isActivacted == true)
        {

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
        foreach (var agent in agentsList)
        {
            agent.gameObject.GetComponent<AI_Agent_Moving>().OnAwakeAgent();
        }
        yield return null;
        StopAllCoroutines();
    }

    IEnumerator WaitAwakeGame()
    {
        yield return new WaitForSeconds(waitTimer);
        coroutine = AwakeGame();
        StartCoroutine(coroutine);
    }
}
