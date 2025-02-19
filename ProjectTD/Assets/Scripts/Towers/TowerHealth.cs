using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    private float maxHealth = 150f;
    private static float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);
    }
}
