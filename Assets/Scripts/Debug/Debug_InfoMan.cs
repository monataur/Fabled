using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_InfoMan : MonoBehaviour
{
    public bool debugInfoEnabled = false;
    public bool debugMenuEnabled = false;
    public GameObject debugInfoMan;
    public Enums.Platform platform;
    public int frameCap;
    void Update()
    {
        if (debugInfoEnabled == true)
        {
            debugInfoMan.SetActive(true);
        }

        else
        {
            debugInfoMan.SetActive(false);
        }
    }
}
