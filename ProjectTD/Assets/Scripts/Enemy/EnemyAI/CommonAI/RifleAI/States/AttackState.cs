using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class AttackState : BaseState
{
    // will be able to reference itself
    private NavMeshAgent agent;
    
    // reference to the core node 
    private Transform coreNodePosition;
    private Transform closestEnemy;
    private LayerMask layerMask = LayerMask.GetMask("Lane", "Wall");
    private RaycastHit hit;

    
    public AttackState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("attack state");
    }
    
    // Update
    public override void Update(GameObject go)
    {
        if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            Debug.Log("Did Not Hit");
        }

    }
    
    
    // Exit
    public override void Exit(GameObject go)
    {
    
    }
    
    // input
    public override BaseState HandleInput(GameObject go)
    {

        return null;
    }
    
}
