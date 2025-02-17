using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    
    // will be able to reference itself
    private NavMeshAgent agent;

    // reference to the core node 
    private Transform coreNodePosition;
    
    // Constructor.
    public IdleState(GameObject go)
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

    }
    
    // Exit
    public override void Exit(GameObject gameObject)
    {
        
    }
    
    // Input
    public override BaseState HandleInput(GameObject go)
    {
        // Idle -> Move
        if ( UnitTracker.UnitTargets != null)
        {
            // if there is only the core node go to the move state that will move to it
            if (UnitTracker.UnitTargets.Count == 1) 
            {
                // Change the state -> MoveState.
                return new MoveState(go);
            }
            // if there is more than one value in the list that means there are obstacles that need to be removed so go to the attack state
            if (UnitTracker.UnitTargets.Count >= 2)
            {
                return new AttackState(go);
            }
        }
        return null;
    }
}