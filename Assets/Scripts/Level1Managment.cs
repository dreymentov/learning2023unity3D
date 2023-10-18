using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level1Managment : MonoBehaviour
{
    public List<GameObject> cubes;

    public GameObject Obstacle1;
    public GameObject Obstacle2;

    public int[] cyclingLifeCubes;

    public float shakerDuration = 0.5f;
    public float shakerStrenght = 0.5f;
    public float moveCycleLength = 2f;
    public float speedMove = -1f;
    public float waitTimer;
    public float waitTimerObs;
    public float minPowerObs = -100;
    public float maxPowerObs = 100;

    public float powerObs1;
    public float powerObs2;

    public int cubNumberCrushing = 0;
    public int minTimerObs = 3;
    public int maxTimerObs = 6;

    public bool startedStop;
    void Start()
    {
        cyclingLifeCubes = new int[cubes.Count];

        for(int i = 0; i < cyclingLifeCubes.Length; i++)
        {
            cyclingLifeCubes[i] = 0;
        }
        startedStop = false;
        StartCoroutine(startGame());
        StartCoroutine(startGameObs());
    }

    private void FixedUpdate()
    {
        if((cubNumberCrushing > 6) && (startedStop == false))
        {
            startedStop = true;
            StopAllCoroutines();
            StartCoroutine(StopObs());
        }
    }

    IEnumerator ShakeCube(int number)
    {
        var cubTf = cubes[number].transform;

        if (cubes.Count == 1)
        {
            StopCoroutine(ShakeCube(number));
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 0)
        {
            cubes[number].gameObject.GetComponent<Renderer>().material.color = Color.green;
            cubTf.DOShakePosition(shakerDuration, shakerStrenght).SetLoops(-1, LoopType.Restart).SetTarget(cubTf);
            cubTf.DOShakeRotation(shakerDuration, shakerStrenght).SetLoops(-1, LoopType.Restart).SetTarget(cubTf);
            //cubTf.DOShakeScale(shakerDuration, shakerStrenght).SetLoops(-1,LoopType.Restart).SetTarget(cubTf);
            cyclingLifeCubes[cubNumberCrushing]++;
            yield return new WaitForSeconds(5f);
            StartCoroutine(ShakeCube(number));
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 1)
        {
            cubes[number].gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            DOTween.Kill(cubTf);
            cubTf.DOMoveY(speedMove, moveCycleLength).SetTarget(cubTf);
            cyclingLifeCubes[cubNumberCrushing]++;
            yield return new WaitForSeconds(2f);
            StartCoroutine(ShakeCube(number));
        }
        else if (cyclingLifeCubes[cubNumberCrushing] == 2)
        {
            DOTween.Kill(cubTf);
            Destroy(cubes[number]);
            cubes.RemoveAt(number);
            cubNumberCrushing++;
            StartCoroutine(ShakeCube(Random.Range(0, cubes.Count)));
        }
        else
        {
            yield break;
        }
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(waitTimer+1);
        StartCoroutine(ShakeCube(Random.Range(0, cubes.Count)));
        
    }
    IEnumerator startGameObs()
    {
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine(randomPowerValue());

    }

    IEnumerator randomPowerValue()
    {
            var waitTimerObs = Random.Range(minTimerObs, maxTimerObs);
            powerObs1 = Random.Range(minPowerObs, maxPowerObs);
            powerObs2 = Random.Range(minPowerObs, maxPowerObs);
            Obstacle1.GetComponent<Obsctacles>().powerObstacl = powerObs1;
            Obstacle2.GetComponent<Obsctacles>().powerObstacl = powerObs2;
            yield return new WaitForSeconds(waitTimerObs);
            StartCoroutine(randomPowerValue());
    }

    IEnumerator StopObs()
    {
        Obstacle1.GetComponent<Obsctacles>().powerObstacl = 0;
        Obstacle2.GetComponent<Obsctacles>().powerObstacl = 0;
        yield break;
    }
}
