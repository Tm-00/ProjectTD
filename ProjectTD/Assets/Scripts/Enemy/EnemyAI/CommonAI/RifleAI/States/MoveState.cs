using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveState : BaseState
{
    
    // will be able to reference itself
    private NavMeshAgent agent;

    // reference to the core node 
    private Transform coreNodePosition;
    
    // Constructor.
    public MoveState(GameObject go)
    {
     
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
        coreNodePosition = UnitTracker.UnitTargets[0].transform;
    }
    
    // Update
    public override void Update(GameObject go)
    {
        if (UnitTracker.UnitTargets.Count == 1)
        {
            agent.destination = coreNodePosition.position;
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
        if (UnitTracker.UnitTargets.Count > 1)
        {
            return new AttackState(go);
        }
        return null;
    }
}