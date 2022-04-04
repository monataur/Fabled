using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Debug_CurrentScene : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = "SCENE: " + SceneManager.GetActiveScene().name;
    }
}
