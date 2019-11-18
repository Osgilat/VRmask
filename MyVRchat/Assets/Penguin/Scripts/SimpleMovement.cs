using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent;
    LookAt lookAt;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updatePosition = false;
        lookAt = GetComponent<LookAt>();
    }

    float maxDX = 0;
    float maxDY = 0;

    void Update()
    {
        Vector3 deltaPosition = agent.nextPosition - transform.position;
        float dx = Vector3.Dot(transform.forward, deltaPosition);
        float dy = Vector3.Dot(transform.right, deltaPosition);
        maxDX = Mathf.Max(maxDX, dx);
        maxDY = Mathf.Max(maxDY, dy);
        Vector2 movement = new Vector2(dx, dy);

        Vector2 velocity = movement / Time.deltaTime;
        float blend = 0;
        bool shouldMove = (velocity.magnitude >= 0.01);

        //если агент хочет повернуться, то пусть он повернётся на месте, а не в ри перемещении
        if (shouldMove && Mathf.Abs(velocity.y) > 0.1)
        {
            agent.nextPosition = transform.position;
            if (velocity.y < 0)
                blend = 0;
            else blend = 1;
                blend = Mathf.Max(blend, -1);
        }
        else if (shouldMove)
        {
            transform.position = agent.nextPosition;
            blend = 0.5f;
        }

        anim.SetBool("isMove", shouldMove);
        anim.SetFloat("blend", blend);

        if (lookAt)
            lookAt.lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }
}
