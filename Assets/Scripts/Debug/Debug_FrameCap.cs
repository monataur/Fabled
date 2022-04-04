using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_FrameCap : MonoBehaviour
{
    public Text text;
    public GameObject infoMan;
    void Update()
    {
        text.text = "FPSCAP: " + infoMan.GetComponent<Debug_InfoMan>().frameCap;
    }
}
