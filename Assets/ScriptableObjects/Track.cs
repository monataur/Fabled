using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Track", menuName = "Track")]
public class Track : ScriptableObject
{
    public new string name;
    public AudioClip start; // is used incase the battle music has a start that needs to play once
    public AudioClip loop; // is used either way
    public bool usesStart;
}
