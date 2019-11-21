using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Targets : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    GameObject target1, target2, target3, target4, target5;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            agent.SetDestination(target1.transform.position);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            agent.SetDestination(target2.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            agent.SetDestination(target3.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            agent.SetDestination(target4.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            agent.SetDestination(target5.transform.position);
        }
    }
}
