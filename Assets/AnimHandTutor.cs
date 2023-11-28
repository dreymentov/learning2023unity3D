using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimHandTutor : MonoBehaviour
{
    public float duration;
    public float posX;
    public float posY;
    [SerializeField] private Ease easeType;
    [SerializeField] private LoopType loopType;

    private void Start()
    {
        this.transform.DOLocalMove(new Vector3(posX, posY, 0), duration).SetEase(easeType).SetLoops(-1, loopType);
        //StartCoroutine(handMove());
    }

    IEnumerator handMove()
    {
        this.transform.DOLocalMove(new Vector3(posX, posY, 0), duration).SetEase(easeType).SetLoops(-1, loopType);
        yield return new WaitForSeconds(duration);
        yield return null;
    }
}
