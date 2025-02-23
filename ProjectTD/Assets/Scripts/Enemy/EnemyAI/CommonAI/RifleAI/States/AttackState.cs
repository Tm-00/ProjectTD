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
    private int amount = 0;
    private bool enemyKilled;

    
    public AttackState(GameObject go)
    {
        // assign variables 
        agent = go.gameObject.GetComponent<NavMeshAgent>();
        coreNodePosition = UnitTracker.UnitTargets[0].transform;
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        Debug.Log("Rifle Drone: Attack State");
        Debug.Log(coreNodePosition);
    }

    // Update
    public override void Update(GameObject go)
    {
        if (cooldownTime <= 0)
        {
            cooldownTime = cooldown;
            if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), out hit, 5f, layerMask))
            {
                GameObject targethit = hit.collider.gameObject;
                AttackTarget(targethit);
                
                TowerHealth targetHealth = targethit.GetComponent<TowerHealth>();
                if (targetHealth.Death())
                {
                    enemyKilled = true;
                }
            }
        }
        else
        {
            cooldownTime -= Time.deltaTime;
        }
    }
    
    
    // Exit
    public override void Exit(GameObject go)
    {
    
    }
    
    // input
    public override BaseState HandleInput(GameObject go)
    {
        if (enemyKilled)
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

            targetHealth.TakeDamage(amount);
            if (targetHealth.Death())
            {
                ObjectPoolManager.ReturnObjectToPool(targethit);
            }
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
    }
}
    

