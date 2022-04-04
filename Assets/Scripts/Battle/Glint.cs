using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glint : MonoBehaviour
{
    public Animator animator;
    public GameObject cam;
    public Image bars;
    public Color transparent;
    public float speed;
    public bool fadingIn;
    public SpriteRenderer glint;
    public AudioSource sound;
    public enum Target {Party1, Party2, Party3, Party4, Enemy1, Enemy2, Enemy3, Enemy4}
    public Target target;
    public GameObject glintParty1;
    public GameObject glintParty2;
    public GameObject glintParty3;
    public GameObject glintParty4;
    public GameObject glintEnemy1;
    public GameObject glintEnemy2;
    public GameObject glintEnemy3;
    public GameObject glintEnemy4;
    public GameObject glintman;

    private void Start()
    {
        animator.speed = 0;
        glint.color = transparent;
    }

    private void Update()
    {
        animator = GlintSelect().GetComponent<Animator>();
        glint = GlintSelect().GetComponent<SpriteRenderer>();
    }

    public void StartAnimation()
    {
        var partyColor = Color.white;
        if(target == Target.Party1 | target == Target.Party2 | target == Target.Party3 | target == Target.Party4)
        {
            partyColor = GlintSelect().GetComponent<GlintPosition>().party.color;
        }
        StartCoroutine(EndAnimation());
        glint.color = new Color(partyColor.r, partyColor.g, partyColor.b);
        fadingIn = true;
        animator.speed = 2.5f;
        bars.color = Color.white;
        cam.GetComponent<BattleCam>().TStatus = TargetStatus();
        cam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.HighZoomIn;
        sound.Play();
    }

    BattleCam.TargetStatus TargetStatus()
    {
        switch (target)
        {
            case Target.Enemy1:
                return BattleCam.TargetStatus.LookEnemy1;
            case Target.Enemy2:
                return BattleCam.TargetStatus.LookEnemy2;
            case Target.Enemy3:
                return BattleCam.TargetStatus.LookEnemy3;
            case Target.Enemy4:
                return BattleCam.TargetStatus.LookEnemy4;
            case Target.Party1:
                return BattleCam.TargetStatus.LookParty1;
            case Target.Party2:
                return BattleCam.TargetStatus.LookParty2;
            case Target.Party3:
                return BattleCam.TargetStatus.LookParty3;
            case Target.Party4:
                return BattleCam.TargetStatus.LookParty4;
            default:
                return BattleCam.TargetStatus.LookInbetween;
        }
    }

    GameObject GlintSelect()
    {
        switch (target)
        {
            case Target.Enemy1:
                return glintEnemy1;
            case Target.Enemy2:
                return glintEnemy2;
            case Target.Enemy3:
                return glintEnemy3;
            case Target.Party1:
                return glintParty1;
            case Target.Party2:
                return glintParty2;
            case Target.Party3:
                return glintParty3;
            default:
                return glintEnemy1;
        }
    }

    public IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(2);
        bars.color = transparent;
        cam.GetComponent<BattleCam>().zoomStatus = BattleCam.ZoomSize.Default;
        cam.GetComponent<BattleCam>().TStatus = BattleCam.TargetStatus.LookInbetween;
        fadingIn = false;
    }
}
