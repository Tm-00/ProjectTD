using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLocateEnemyState : TurretBaseState
{
    private Vector3 closestTarget;
    
    public TurretLocateEnemyState(GameObject go)
    {
        
    }
    public override void Enter(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(GameObject go)
    {
        var cloestEnemy = UnitTracker.FindClosestEnemey(go);
        if (cloestEnemy != null)
        {
            closestTarget = UnitTracker.FindClosestEnemey(go).transform.position;
            go.transform.LookAt(closestTarget);
        }
    }

    public override void Exit(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override BaseState HandleInput(GameObject go)
    {
        // Move -> Attack
        if (Vector3.Distance(go.transform.position, closestTarget) <= 10)
        {
            return new AttackState(go);
        }

        return null;
    }
}