using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_Platform : MonoBehaviour
{
    public Text text;
    void Update()
    {       
        text.text = "PLATFORM: " + Application.platform.ToString().ToUpper();
    }
}
