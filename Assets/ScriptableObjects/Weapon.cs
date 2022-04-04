using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public string description;
    public Enums.Element element;
    public Enums.EquipType type;
    public Enums.Element runeResist;
    public Enums.Element runeWeak;
}
