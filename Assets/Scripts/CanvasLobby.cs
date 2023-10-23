using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLobby : MonoBehaviour
{
    public RectTransform Panel;

    void Update()
    {
        if (Panel.gameObject.activeSelf == true)
        {
            if (Input.GetKeyUp("f1"))
            {
                Panel.gameObject.SetActive(false);
            }
        }
        else if (Panel.gameObject.activeSelf == false)
        {
            if (Input.GetKeyUp("f1"))
            {
                Panel.gameObject.SetActive(true);
            }
        }
    }
}
