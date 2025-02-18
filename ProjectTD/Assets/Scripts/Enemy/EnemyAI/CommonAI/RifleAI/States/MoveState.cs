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
        // switch to determine if what target is closest, core node or a lane unit
        switch (UnitTracker.UnitTargets.Count)
        {
            case 1:
                agent.destination = coreNodePosition.position;
                break;
            case > 1:
                // Find the closest enemy
                Transform closestEnemy = UnitTracker.FindClosestEnemy(agent).transform;
                Vector3 directionToTarget = closestEnemy.position - agent.transform.position;
                
                float distanceToStop = 5f;
                if (directionToTarget.sqrMagnitude > distanceToStop)
                {
                    Vector3 stopPosition = closestEnemy.position - directionToTarget.normalized * distanceToStop;
                    agent.destination = stopPosition;
                }
                else
                {
                    agent.destination = agent.transform.position;
                }
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
        if (Vector3.Distance(agent.transform.position, closestTarget) <= 5)
        {
            return new AttackState(go);
        }
        return null;
    }
}