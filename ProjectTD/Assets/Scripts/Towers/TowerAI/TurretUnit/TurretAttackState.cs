using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretBaseState
{
    private Transform closestTarget;
    private LayerMask layerMask = LayerMask.GetMask("Towers");
    private RaycastHit hit;
    private float cooldown = 5f;
    private float cooldownTime;
    private int amount = 50;

    public TurretAttackState(GameObject go)
    {
        
    }
    
    public override void Enter(GameObject go)
    {
        Debug.Log("Turret Attack State");
    }

    public override void Update(GameObject go)
    {
        if (Physics.Raycast(go.transform.position, go.transform.TransformDirection(Vector3.forward), out hit, 5f, layerMask))
        {
            GameObject targethit = hit.collider.gameObject;
            AttackTarget(targethit, go);
            
            EnemyHealth enemyHealth = targethit.GetComponent<EnemyHealth>();
            
            if (enemyHealth.EnemyDeath())
            {
                Debug.Log("array length " + UnitTracker.enemyArray.Length);
                if (UnitTracker.enemyArray.Length > 1)
                {
                    closestTarget = UnitTracker.FindClosestEnemey(go).transform;
                    go.transform.forward = closestTarget.position;
                }
            }
        }
    }

    public override void Exit(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override BaseState HandleInput(GameObject go)
    {
        throw new System.NotImplementedException();
    }
    
    // TODO change into a public method in a different class that all units can use
    private void AttackTarget(GameObject targethit, GameObject go)
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
            Debug.DrawRay(go.transform.position, go.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        //Debug.Log("Did Hit");
    }
}
