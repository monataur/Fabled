using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlintAnim : StateMachineBehaviour
{
    public int count;
    public GameObject glint;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 0;
    }
}
