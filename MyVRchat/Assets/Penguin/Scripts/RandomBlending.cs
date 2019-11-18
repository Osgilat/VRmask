using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlending : StateMachineBehaviour
{
    [SerializeField] GameObject character;
    public string parameterName;
    private float randomBlend;
    private Animator animator;
    private void Awake()
    {
        animator = character.GetComponent<Animator>();
    }
    void OnStateEnter()
    {
        randomBlend = Random.value;
        animator.SetFloat(parameterName, randomBlend);
    }
    void OnStateUpdate()
    {
        randomBlend = Random.value;
        animator.SetFloat(parameterName, randomBlend);
    }
}
