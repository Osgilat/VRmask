using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInt : StateMachineBehaviour
{
    public string parameterName;
    public int numberOfStates;
    private int randomInt;
    private float randomValue;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomValue = Random.value;
        randomInt = Mathf.FloorToInt(randomValue * numberOfStates);
        animator.SetInteger(parameterName, randomInt);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomValue = Random.value;
        randomInt = Mathf.FloorToInt(randomValue * numberOfStates);
        animator.SetInteger(parameterName, randomInt);
    }
}
