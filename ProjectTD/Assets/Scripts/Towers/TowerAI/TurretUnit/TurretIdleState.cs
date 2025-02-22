using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretBaseState
{
    public TurretIdleState(GameObject go)
    {
        Debug.Log("IdleState");
    }
    public override void Enter(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override BaseState HandleInput(GameObject go)
    {
        if (UnitTracker.EnemyTargets != null)
        {
            if (UnitTracker.EnemyTargets.Count > 1)
            {
                return new TurretAttackState(go);
            }
        }
        return null;
    }
}
