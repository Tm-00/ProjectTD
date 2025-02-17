using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class AttackState : BaseState
{
    // will be able to reference itself
    private NavMeshAgent agent;
    
    // reference to the core node 
    private Transform closestTarget;
    
    public AttackState(GameObject go)
    {

    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();

        for (int i = 0; i < UnitTracker.UnitTargets.Count; i++)
        {
            //TODO add logic to find cloest target from a list 
        }
    }
    
    // Update
    public override void Update(GameObject go)
    {

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
