using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovement : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    LookAt lookAt;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        lookAt = GetComponent<LookAt>();
    }

    void Update()
    {
        Vector3 deltaPosition = agent.nextPosition - transform.position;
        float dx = Vector3.Dot(transform.forward, deltaPosition);
        float dy = Vector3.Dot(transform.right, deltaPosition);
        Vector2 movement = new Vector2(dx, dy);
        Vector2 velocity = Vector2.zero;

        if (Time.deltaTime > 1e-5)
        {
            velocity = movement / Time.deltaTime;
        }
        float animTurnParam = 0;
        bool isMove = (velocity.magnitude >= 0.01);

        //если агент хочет повернуться, то пусть он повернётся на месте, а не в ри перемещении
        if (isMove && Mathf.Abs(velocity.y) > 0.1)
        {
            agent.nextPosition = transform.position;
            if (velocity.y < 0)
                animTurnParam = 1f;//поворот налево
            else animTurnParam = -1f;//поворот направо
        }
        else if (isMove)
        {
            transform.position = agent.nextPosition;
            animTurnParam = 0f;//движение прямо
        }

        anim.SetBool("isMove", isMove);
        anim.SetFloat("turn", animTurnParam);

        if (lookAt)
            lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }
}
