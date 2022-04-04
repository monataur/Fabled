using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Resolution : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = "RESOLUTION: " + Screen.currentResolution;
    }
}
