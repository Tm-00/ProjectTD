using UnityEngine;

public class IdleState : BaseState
{
    // An array of gameObjects (gos)
    private GameObject[] gos;
    //stores a reference to the player
    private GameObject Player = null;
    // Projectile hit event variables
    
    // Constructor.
    public IdleState(GameObject go)
    {
        //Find the player
        // there should be one object tagged with player.
        //TODO implement corenode
        gos = GameObject.FindGameObjectsWithTag("CoreNode");
        if ( gos.Length > 0)
        {
            Player = gos[0];
        }
        else
        {
            Debug.Log("Core Node Is Destroyed");
        }
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
        if (Player != null)
        {
            //TODO change play scripts to core node scripts
            //if (Vector3.Distance(go.transform.position, Player.transform.position) >= 11 && PlayerHealth._playerCurrentHealth > 0) 
            {
                // Change the state - retreat.
                //return new ChasePlayerState(go);
            }
        }
        return null;
    }
    
}