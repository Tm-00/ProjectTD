using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    // A list of gameObjects 
    private List<GameObject> navMeshTargets = new List<GameObject>();
    
    // will be able to refence itself
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
        // get a reference to the core node and place it at initial index
        navMeshTargets.Insert(0, FSM_CON.coreNode);
        agent = go.gameObject.GetComponent<NavMeshAgent>();

        coreNodePosition = navMeshTargets[0].transform;
    }
    
    // Update
    public override void Update(GameObject go)
    {
        // find every floor unit placed add it to a list 
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FloorUnit"))
        {
            navMeshTargets.Add(obj);
        }
    }
    
    // Exit
    public override void Exit(GameObject gameObject)
    {
        
    }
    
    // Input
    public override BaseState HandleInput(GameObject go)
    {
        // Idle -> Move
        if ( navMeshTargets != null)
        {
            // if there is only the core node go to the move state that will move to it
            if (navMeshTargets.Count == 1) 
            {
                // Change the state -> MoveState.
                return new MoveState(go);
            }
            // if there is more than one value in the list that means there are obstacles that need to be removed so go to the attack state
            if (navMeshTargets.Count >= 2)
            {
                return new AttackState(go);
            }
        }
        return null;
    }
}