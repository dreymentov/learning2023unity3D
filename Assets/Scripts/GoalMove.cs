using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalMove : MonoBehaviour
{
    public float movePosY;
    public float movePosZ;

    public float TimeToStart;
    public float MoveDurationY;
    public float MoveDurationZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartMoveWithTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //this.transform.position += new Vector3(movePosX * Time.fixedDeltaTime, movePosY * Time.fixedDeltaTime, movePosZ * Time.fixedDeltaTime);
    }

    IEnumerator StartMoveWithTimer()
    {
        yield return new WaitForSeconds(TimeToStart);
        this.transform.DOLocalMoveZ(movePosZ, MoveDurationZ);
        this.transform.DOLocalMoveY(movePosY, MoveDurationY);
        yield return null;
    }
}
