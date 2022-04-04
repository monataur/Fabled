using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMemberObject : MonoBehaviour
{
    public new string name;
    public string description;
    public string title;
    public Enums.Element element;
    public Sprite sprite;
    public Sprite icon;
    public RuntimeAnimatorController animator;
    public PartyMember partyMember;
    public void Update()
    {
        name = partyMember.name;
        description = partyMember.description;
        title = partyMember.title;
        element = partyMember.element;
        sprite = partyMember.sprite;
        icon = partyMember.icon;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = partyMember.animator;
    }
}
