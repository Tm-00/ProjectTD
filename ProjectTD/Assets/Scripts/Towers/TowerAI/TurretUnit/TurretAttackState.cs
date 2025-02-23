using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretAttackState : TurretBaseState
{
    private Transform closestTarget;
    private LayerMask layerMask = LayerMask.GetMask("Enemies");
    private RaycastHit hit;
    private float cooldown = 5f;
    private float cooldownTime;
    private int amount = 50;

    private NavMeshAgent agent;

    public TurretAttackState(GameObject go)
    {
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    
    public override void Enter(GameObject go)
    {
        Debug.Log("Turret: Attack State");
    }

    public override void Update(GameObject go)
    {
        //TODO change logic so that it finds and identifies the enemy first then shoots raycast
        //closestTarget = UnitTracker.FindClosestEnemy(agent).transform;
        //agent.updateRotation = closestTarget.transform;
        
        if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), out hit, 5f, layerMask))
        {
            GameObject targethit = hit.collider.gameObject;
            AttackTarget(targethit);
            
            EnemyHealth enemyHealth = targethit.GetComponent<EnemyHealth>();
            
            if (enemyHealth.EnemyDeath())
            {
                Debug.Log("array length " + UnitTracker.enemyArray.Length);
                if (UnitTracker.enemyArray.Length > 1)
                {
                    closestTarget = UnitTracker.FindClosestEnemy(agent).transform;
                    agent.updateRotation = closestTarget.transform;
                }
            }
        }
    }

    public override void Exit(GameObject go)
    {
        
    }

    public override TurretBaseState HandleInput(GameObject go)
    {
        return null;
    }
    
    // TODO change into a public method in a different class that all units can use
    private void AttackTarget(GameObject targethit)
    {
        if (targethit != null)
        {
            EnemyHealth enemyHealth = targethit.GetComponent<EnemyHealth>();
            if (cooldownTime <= 0)
            {
                cooldownTime = cooldown;
                enemyHealth.EnemyTakeDamage(amount);
            }
            else
            {
                cooldownTime -= Time.deltaTime;
                //Debug.Log("active cd time " + cooldownTime);
            }
            if (enemyHealth.EnemyDeath())
            {
                ObjectPoolManager.ReturnObjectToPool(targethit);
            }
            Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        //Debug.Log("Did Hit");
    }
}
