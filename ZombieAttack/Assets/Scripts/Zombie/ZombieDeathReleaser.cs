using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathReleaser : StateMachineBehaviour
{
    private float beginPoint = 0.0f;
    private bool isNextPlaying;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isNextPlaying = (Time.time - beginPoint) > stateInfo.length / 3.15f;
        if (isNextPlaying)
        {
            animator.GetComponent<CapsuleCollider>().height = 1.0f;
            beginPoint = Time.time;
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        beginPoint = Time.time;
    }
}
