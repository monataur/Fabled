using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party Member", menuName = "Party Member")]
public class PartyMember : ScriptableObject
{
    public new string name;
    public string description;
    public string title;
    public Enums.Element element;
    public Enums.Element resist;
    public Enums.Element weak;
    public Enums.EquipType equip;
    public Sprite sprite;
    public Sprite icon;
    public Vector3 glint;
    public Color color;
    public Color menu;
    public AudioClip voice;
    public RuntimeAnimatorController animator;
    public int[] moveset = new int[8];
    public int[] movepool = new int[20];
}
