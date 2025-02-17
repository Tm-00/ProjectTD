using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveState : BaseState
{
    // A list of gameObjects 
    private List<GameObject> navMeshTargets = new List<GameObject>();
    
    // will be able to refence itself
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
        // get a reference to the core node and place it at initial index
        navMeshTargets.Insert(0, FSM_CON.coreNode);
        agent = go.gameObject.GetComponent<NavMeshAgent>();

        coreNodePosition = navMeshTargets[0].transform;
    }
    
    // Update
    public override void Update(GameObject go)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FloorUnit"))
        {
            navMeshTargets.Add(obj);
        }
        if (navMeshTargets.Count == 1)
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
        if (navMeshTargets.Count > 1)
        {
            return new AttackState(go);
        }
        return null;
    }
}