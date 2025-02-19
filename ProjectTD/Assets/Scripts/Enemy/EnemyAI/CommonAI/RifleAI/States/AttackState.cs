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
    private LayerMask layerMask = LayerMask.GetMask("Towers");
    private RaycastHit hit;

    
    public AttackState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("attack state");
        
        if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), 10f, layerMask))
        {
            
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            //Debug.Log("Did Not Hit");
        }
    }
    
    // Update
    public override void Update(GameObject go)
    {
        if (hit.collider.gameObject.CompareTag("WallUnit"))
        {
            
        }
 
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
