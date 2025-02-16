using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CNHealth : MonoBehaviour
{
    [SerializeField] private GameObject coreNode;
    private static readonly int MaxHealth = 10;
    private static int _currentHealth = 10;
    private static readonly int Amount = 1;
    public static bool Hit = false;
    public static bool IsDead = false;
    
    private static int HealthHandler(bool takenDamage)
    {
        if (takenDamage)
        {
            // Reset the flag after handling the event
            Hit = false;
            _currentHealth -= Amount;
            Debug.Log("Core Node Health: "+ _currentHealth + "/" +  MaxHealth);
        }
        return _currentHealth;
    }

    public static bool CoreNodeDead()
    {
        if (_currentHealth <= 0)
        {
            IsDead = true;
        }
        return IsDead;
    }
    
    
    public void OnCollisionEnter(Collision col)
    {
        //TODO might have to reconsider how enemy tags work
        if (col.gameObject.tag.Contains("Enemy"))
        {
            GameObject.Destroy(col.gameObject);
            Hit = true;
        }
    }
}
