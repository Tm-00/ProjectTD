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

    private List<GameObject> localList;
    
    // Constructor.
    public MoveState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
        coreNodePosition = UnitTracker.UnitTargets[0].transform;
        localList = UnitTracker.UnitTargets;
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("Move State");
    }
    
    // Update
    public override void Update(GameObject go)
    {
        // switch to determine if what target is closest, core node or a lane unit
        switch (localList.Count)
        {
            case 1:
                agent.destination = coreNodePosition.position;
                break;
            case > 1:
                // Find the closest enemy
                closestTarget = UnitTracker.FindClosestEnemy(agent).transform.position;
                agent.destination = closestTarget;
                break;
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
        return null;
    }
}