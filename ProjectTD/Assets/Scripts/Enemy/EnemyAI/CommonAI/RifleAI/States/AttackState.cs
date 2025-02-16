using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    // an array of gameobjects gos
    private GameObject[] gos;
    
    // stores a reference to the player
    private GameObject Player = null;
    
    private static bool startAttack = false;
    
    private static bool attackPlayer = false;
    
    public AttackState(GameObject go)
    {
        // Find the player 
        gos = GameObject.FindGameObjectsWithTag("Player");
        if (gos.Length > 0)
        {
            Player = gos[0];
        }

        if (Player != null)
        {
            go.transform.LookAt(Player.transform.position);
        }
        else
        {
            Debug.Log("No Player Found");
        }
        
        
    }
    
    // Enter
    public override void Enter(GameObject go)
    {
        attackPlayer = true;
    }
    
    // Update
    public override void Update(GameObject go)
    {
        startAttack = true;
        Vector3 direction = Player.transform.position - go.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        go.transform.rotation = rotation;
    }
    
    // Exit
    public override void Exit(GameObject go)
    {
        startAttack = false;
        attackPlayer = false;
    }
    
    // input
    public override BaseState HandleInput(GameObject go)
    {
        // Attack -> Idle
        if (PlayerHealth._playerCurrentHealth <= 0)
        {
            // Change the state.
            return new IdleState(go);
        }
        
        // Attack -> Chase
        if (Vector3.Distance(go.transform.position, Player.transform.position) >= 11)
        {
            // Change the state.
            return new ChasePlayerState(go);
        }
        
        // Attack -> Retreat
        if (Vector3.Distance(go.transform.position, Player.transform.position) >= 5 && BossHealth.HealthHandler() <= 30)
        {
            // Change the state.
            return new RetreatState(go);
        }
       // else if (Vector3.Distance(go.transform.position, Player.transform.position) >= 11 && BossHealth.HealthHandler() <= 30)
       // {
            // Change the state.
       //     return new RetreatState(go);
      //  }
        
        // Attack -> Dead
        if (BossHealth.HealthHandler() == 0 || BossHealth.HealthHandler() < 0)
        {
            // Change the state.
            return new DeadState(go);
        }
        
        return null;
    }

    public static bool IsAttacking()
    {
        if (startAttack == true)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    
    public static bool attackPlayerAnim()
    {
        if (attackPlayer)
        { 
            return true;
        }
        else
        {
            return false;
        }
       
    }
    
}
