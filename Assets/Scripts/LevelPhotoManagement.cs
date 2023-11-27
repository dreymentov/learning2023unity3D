using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPhotoManagement : MonoBehaviour
{
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickToScreenshoting()
    {
        {
            ScreenCapture.CaptureScreenshot("Screenshot"+i, 1);
        }
        Debug.Log("ScreenShoted"+i);
        i++;
    }
}
