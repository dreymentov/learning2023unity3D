using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net.NetworkInformation;
using UnityEngine.SceneManagement;

public class panelWinScript : MonoBehaviour
{
    public GameObject roundL;
    public GameObject roundR;
    public GameObject PingL;
    public GameObject PingR;
    public GameObject BlueL;
    public GameObject BlueR;

    public bool isInvoked;


    [SerializeField] private Ease easeType;

    void Start()
    {
        isInvoked = false;
        StartCoroutine(StartPos());
    }

    void Update()
    {

    }
    IEnumerator StartPos()
    {
        roundL.transform.DOMoveX(roundL.transform.position.x - 1300, 0f);
        roundR.transform.DOMoveX(roundR.transform.position.x + 1300, 0f);
        PingL.transform.DOMoveX(PingL.transform.position.x - 400, 0f);
        PingR.transform.DOMoveX(PingR.transform.position.x + 400, 0f);
        BlueL.transform.DOMoveX(BlueL.transform.position.x - 400, 0f);
        BlueR.transform.DOMoveX(BlueR.transform.position.x + 400, 0f);
        yield return null;
    }

    IEnumerator WinPos()
    {
        roundL.transform.DOMoveX(roundL.transform.position.x + 1300, 0.25f).SetEase(easeType);
        roundR.transform.DOMoveX(roundR.transform.position.x - 1300, 0.25f);
        yield return new WaitForSeconds(0.3f);
        PingL.transform.DOMoveX(PingL.transform.position.x + 400, 0.3f);
        yield return new WaitForSeconds(0.1f);
        PingL.transform.DOShakeScale(0.2f);
        PingR.transform.DOMoveX(PingR.transform.position.x - 400, 0.4f);
        yield return new WaitForSeconds(0.1f);
        PingR.transform.DOShakeScale(0.2f);
        yield return new WaitForSeconds(0.4f);
        BlueL.transform.DOMoveX(BlueL.transform.position.x + 400, 0.4f);
        yield return new WaitForSeconds(0.1f);
        BlueL.transform.DOShakeScale(0.2f);
        BlueR.transform.DOMoveX(BlueR.transform.position.x - 400, 0.3f);
        yield return new WaitForSeconds(0.1f);
        BlueR.transform.DOShakeScale(0.2f);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Lobby");
        yield return null;
    }

    public void panelWinInvoke()
    {
        if(isInvoked == false)
        {
            isInvoked = true;
            StartCoroutine(WinPos());
        }
        else
        {
            Debug.Log("Invoked in the level");
        }
    }
}
