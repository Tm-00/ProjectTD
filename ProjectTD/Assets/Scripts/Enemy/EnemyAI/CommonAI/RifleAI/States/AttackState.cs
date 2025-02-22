using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class AttackState : BaseState
{
    // will be able to reference itself
    private NavMeshAgent agent;
    
    // reference to the core node 
    private Transform coreNodePosition;
    private Transform closestTarget;
    private LayerMask layerMask = LayerMask.GetMask("Towers");
    private RaycastHit hit;
    private float cooldown = 5f;
    private float cooldownTime;
    private int amount = 50;
    private bool transitionState;

    
    public AttackState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("attack state");
    }
    
    // Update
    public override void Update(GameObject go)
    {
        if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), out hit, 5f, layerMask))
        {
            GameObject targethit = hit.collider.gameObject;
            AttackTarget(targethit);
            
            TowerHealth targetHealth = targethit.GetComponent<TowerHealth>();
            
            if (targetHealth.Death())
            {
                Debug.Log("array length " + UnitTracker.gos.Length);
                if (UnitTracker.gos.Length > 1)
                {
                    closestTarget = UnitTracker.FindClosestEnemy(agent).transform;
                    agent.destination = closestTarget.position;
                }
            }
        }
    }
    
    
    // Exit
    public override void Exit(GameObject go)
    {
    
    }
    
    // input
    public override BaseState HandleInput(GameObject go)
    {
        if (UnitTracker.gos.Length == 1)
        {
            return new MoveState(go);
        }
        return null;
    }
    
    // TODO change into a public method in a different class that all units can use
    private void AttackTarget(GameObject targethit)
    {
        if (targethit != null)
        {
            TowerHealth targetHealth = targethit.GetComponent<TowerHealth>();
            if (cooldownTime <= 0)
            {
                cooldownTime = cooldown;
                targetHealth.TakeDamage(amount);
            }
            else
            {
                cooldownTime -= Time.deltaTime;
                //Debug.Log("active cd time " + cooldownTime);
            }
            if (targetHealth.Death())
            {
                ObjectPoolManager.ReturnObjectToPool(targethit);
            }
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        //Debug.Log("Did Hit");
    }
}
    

