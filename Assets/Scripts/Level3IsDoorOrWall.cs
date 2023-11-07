using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using DG.Tweening;

public class Level3IsDoorOrWall : MonoBehaviour
{
    public GameObject[] Doors;
    public Level3DoorStartLevel[] level3door;
    public bool[] DoorsBool;
    public NavMeshObstacle NMO;
    public bool Opened;
    public bool Closed;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Opened = false;
        Closed = false;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if(Opened == false)
        {
            Opened = true;
            StartCoroutine(OpenDoors());
        }

        if (Closed == false)
        {
            Closed = true;
            StartCoroutine(CloseDoors());
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for(int i = 0; i < Doors.Length; i++)
        {
            level3door[i] = Doors[i].GetComponent<Level3DoorStartLevel>();
        }

        foreach (var door in Doors)
        {
            NMO = door.GetComponent<NavMeshObstacle>();
            Destroy(NMO);
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(1f);

        int i = 0;

        if (Doors.Length > 3)
        {
            i = Random.Range(0, 99);

            if(i >= 74)
            {
                level3door[3].IsDoor = true;
            }
            else if(i >= 49 && i < 74)
            {
                level3door[2].IsDoor = true;
            }
            else if (i >= 24 && i < 49)
            {
                level3door[1].IsDoor = true;
            }
            else
            {
                level3door[0].IsDoor = true;
            }

            i = Random.Range(0, 99);

            if (i >= 74)
            {
                level3door[3].IsDoor = true;
            }
            else if (i >= 49 && i < 74)
            {
                level3door[2].IsDoor = true;
            }
            else if (i >= 24 && i < 49)
            {
                level3door[1].IsDoor = true;
            }
            else
            {
                level3door[0].IsDoor = true;
            }
        }
        else if (Doors.Length == 3)
        {
            i = Random.Range(0, 99);

            if (i >= 65)
            {
                level3door[2].IsDoor = true;
            }
            else if (i >= 32 && i < 65)
            {
                level3door[1].IsDoor = true;
            }
            else
            {
                level3door[0].IsDoor = true;
            }

            i = Random.Range(0, 99);

            if (i >= 65)
            {
                level3door[2].IsDoor = true;
            }
            else if (i >= 32 && i < 65)
            {
                level3door[1].IsDoor = true;
            }
            else
            {
                level3door[0].IsDoor = true;
            }
        }
        else if (Doors.Length < 3)
        {
            i = Random.Range(0, 99);

            if (i >= 49)
            {
                level3door[1].IsDoor = true;
            }
            else
            {
                level3door[0].IsDoor = true;
            }
        }
        else
        {
            Debug.Log("doors Length < 2");
        }

        yield return null;
    }

    IEnumerator CloseDoors()
    {
        for (int i = 0; i < level3door.Length; i++)
        {
            level3door[i].IsDoor = false;
            level3door[i].transform.localPosition = level3door[i].NativePos;
            Debug.Log("Closed");
        }
        yield break;
    }
}
