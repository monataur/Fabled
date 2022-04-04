using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlintPosition : MonoBehaviour
{
    public Vector3 glintposition;
    public Transform glinttrans;
    public Enemy enemy;
    public PartyMember party;
    public bool isParty;

    private void Start()
    {
        glinttrans = transform;
    }

    private void Update()
    {
        if (isParty == true)
        {
            party = transform.GetComponentInParent<PartyMemberObject>().partyMember;
            transform.position = party.glint + transform.parent.position;
        }
        else if (isParty == false)
        {
            enemy = transform.GetComponentInParent<EnemyObject>().enemy;
            transform.position = enemy.glint + transform.parent.position;
        }
    }
}
