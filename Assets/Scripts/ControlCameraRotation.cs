using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCameraRotation : MonoBehaviour
{
    public Transform go_MovingForCamera;

    public float speedsCam = 50f;

    private float X;
    private float eulerY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            X = Input.GetAxis("Mouse X") * speedsCam * Time.deltaTime;
            eulerY = (go_MovingForCamera.transform.rotation.eulerAngles.y + X) % 360;
            go_MovingForCamera.transform.rotation = Quaternion.Euler(0, eulerY, 0); ;
        }
    }
}
