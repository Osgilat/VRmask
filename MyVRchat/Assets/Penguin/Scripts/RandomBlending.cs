using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlending : StateMachineBehaviour
{
    [SerializeField] GameObject character;
    public string parameterName;
    private float randomBlend;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomBlend = Random.value;
        animator.SetFloat(parameterName, randomBlend);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomBlend = Random.value;
        animator.SetFloat(parameterName, randomBlend);
    }
}