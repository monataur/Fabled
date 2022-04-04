using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "Room")]
public class Room : ScriptableObject
{
    public new string name;
    public int id;
    public string description;
    public Enums.Locale locale;
    public AudioClip music;
    public GameObject room;
    public Vector2 start;
}
