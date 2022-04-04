using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public PartyMember party1;
    public PartyMember party2;
    public PartyMember party3;
    public PartyMember party4;
    public GameObject party1Obj;
    public GameObject party2Obj;
    public GameObject party3Obj;
    public GameObject party4Obj;
    public Enums.PartyStatus status = Enums.PartyStatus.Map;
    public int count;
    public Vector2 track;
    private void Update()
    {
        count = CountPartyMembers();
        if (status == Enums.PartyStatus.Map | status == Enums.PartyStatus.Cutscene)
        {
            track = party1Obj.transform.position;
        }
    }
    void Start()
    {
        party1Obj.GetComponent<PartyMemberObject>().partyMember = party1;
        party2Obj.GetComponent<PartyMemberObject>().partyMember = party2;
        party3Obj.GetComponent<PartyMemberObject>().partyMember = party3;
        party4Obj.GetComponent<PartyMemberObject>().partyMember = party4;
    }
    int CountPartyMembers()
    {
        int partycount;

        partycount = 0;

        if (party1.name != "Blank")
        {
            partycount += 1;
            party1Obj.SetActive(true);
        }
        if (party2.name != "Blank")
        {
            partycount += 1;
            party1Obj.SetActive(true);
        }
        if (party3.name != "Blank")
        {
            partycount += 1;
            party1Obj.SetActive(true);
        }
        if (party4.name != "Blank")
        {
            partycount += 1;
            party1Obj.SetActive(true);
        }
        // if blank
        if (party1.name == "Blank")
        {
            party1Obj.SetActive(false);
        }
        if (party2.name == "Blank")
        {
            party2Obj.SetActive(false);
        }
        if (party3.name == "Blank")
        {
            party3Obj.SetActive(false);
        }
        if (party4.name == "Blank")
        {
            party4Obj.SetActive(false);
        }

        return partycount;
    }
}
