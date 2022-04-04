using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Framerate : MonoBehaviour
{
    public Text text;
    public GameObject infoMan;

    private void Start()
    {
        
    }
    void Update()
    {
        Application.targetFrameRate = infoMan.GetComponent<Debug_InfoMan>().frameCap;
        float fps = 1 / Time.unscaledDeltaTime;
        text.text = "FPS: " + fps;
    }
}
