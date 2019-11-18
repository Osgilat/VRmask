using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInt : StateMachineBehaviour
{
    public string parameterName;
    public int numberOfStates;
    private int randomInt;
    private float randomValue;
    private void Awake()
    {
    }
    void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        randomValue = Random.value;
        randomInt = Mathf.FloorToInt(randomValue * numberOfStates);
        animator.SetInteger(parameterName, randomInt);
        Debug.Log("OnStateEnter -" + "\"" + parameterName + "\"" + " = " + randomInt);
    }
    void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        randomValue = Random.value;
        randomInt = Mathf.FloorToInt(randomValue * numberOfStates);
        animator.SetInteger(parameterName, randomInt);
        Debug.Log("OnStateEnter -" + "\"" + parameterName + "\"" + " = " + randomInt);
    }
}
