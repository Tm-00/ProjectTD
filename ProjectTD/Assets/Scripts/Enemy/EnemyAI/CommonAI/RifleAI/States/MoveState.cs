using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveState : BaseState
{
    
    // will be able to reference itself
    private NavMeshAgent agent;

    private Vector3 closestTarget;

    // reference to the core node 
    private Transform coreNodePosition;
    
    // Constructor.
    public MoveState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
        coreNodePosition = UnitTracker.UnitTargets[0].transform;
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("Move State");
    }
    
    // Update
    public override void Update(GameObject go)
    {
        var cloestEnemy = UnitTracker.FindClosestEnemy(agent);
        if (cloestEnemy != null)
        {
            closestTarget = UnitTracker.FindClosestEnemy(agent).transform.position;
            agent.destination = closestTarget;
        }
        else
        {
            agent.destination = coreNodePosition.transform.position;
        }
    }
    
    // Exit
    public override void Exit(GameObject gameObject)
    {
        
    }
    
    // Input
    public override BaseState HandleInput(GameObject go)
    {
        // Move -> Attack
        if (Vector3.Distance(agent.transform.position, closestTarget) <= 6)
        {
            return new AttackState(go);
        }
        if (Vector3.Distance(agent.transform.position, coreNodePosition.transform.position) <= 5)
        {
            return new FinishedState(go);
        }
        return null;
    }
}