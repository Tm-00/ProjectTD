using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretLocateEnemyState : TurretBaseState
{
    private Vector3 closestTarget;
    
    private NavMeshAgent agent;
    
    public TurretLocateEnemyState(GameObject go)
    {
        agent = go.gameObject.GetComponent<NavMeshAgent>();
    }
    public override void Enter(GameObject go)
    {
        Debug.Log("Turret: LocateEnemyState");
    }

    public override void Update(GameObject go)
    {
        var cloestEnemy = UnitTracker.FindClosestEnemy(agent);
        if (cloestEnemy != null)
        {
            closestTarget = UnitTracker.FindClosestEnemy(agent).transform.position;
            go.transform.LookAt(closestTarget);
        }
    }

    public override void Exit(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override TurretBaseState HandleInput(GameObject go)
    {
        // Move -> Attack
        if (Vector3.Distance(go.transform.position, closestTarget) <= 10)
        {
            return new TurretAttackState(go);
        }

        return null;
    }
}