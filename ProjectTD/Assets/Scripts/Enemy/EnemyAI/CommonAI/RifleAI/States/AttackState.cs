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
    

    
    public AttackState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Enter
    public override void Enter(GameObject go)
    {

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
