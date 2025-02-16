using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    // An array of gameObjects (gos)
    private List<GameObject> targets = new List<GameObject>();
    //stores a reference to the units
    private GameObject floorUnits = null;
    private GameObject coreNode = null;
    // reference to the nav mesh
    private NavMeshAgent agent;

    
    // Constructor.
    public IdleState(GameObject go)
    {
        //assign core node and units placed on the floor
        targets.Insert(0, GameObject.FindWithTag("CoreNode")); 
        targets.Add(GameObject.FindWithTag("FloorUnit")); 
        if ( targets[0] == null)
        {
            Debug.Log("Core Node Is Destroyed");
        }
        agent = go.GetComponent<NavMeshAgent>();
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

    public override void Exit(GameObject gameObject)
    {
        
    }
    
    // Input
    public override BaseState HandleInput(GameObject go)
    {
        // Idle -> Move
        if ( targets != null)
        {
            //TODO change player scripts to core node scripts
            //if (Vector3.Distance(go.transform.position, Player.transform.position) >= 11 && PlayerHealth._playerCurrentHealth > 0) 
            {
                // Change the state - retreat.
                //return new ChasePlayerState(go);
            }
        }
        return null;
    }
    
}