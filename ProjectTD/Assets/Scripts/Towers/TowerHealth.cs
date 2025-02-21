using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    private float maxHealth = 50f;
    private static float currentHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public static void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            UnitTracker.UnitTargets.Remove(this.GameObject());
            Debug.Log(UnitTracker.UnitTargets);
            //ObjectPoolManager.ReturnObjectToPool(gameObject);
            //Debug.Log("dead");
        }
    }
}
