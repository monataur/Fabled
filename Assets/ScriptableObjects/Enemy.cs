using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public new string name;
    public string description;
    public string description2;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    public Enums.Element element;
    public Enums.Element resist;
    public Enums.Element weak;
    public Vector3 glint;
}
