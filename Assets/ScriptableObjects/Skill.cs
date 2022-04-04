using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public new string name;
    public string description;
    public Enums.Element element;
    public Enums.DamageSeverity severity;
    public Enums.SkillType skillType;
    //if the skillType is Enums.SkillType.Function, then it will call a function using functionId.
    public int functionId;
    public Enums.DamageType dmgType;
    public AudioClip sound;
}
