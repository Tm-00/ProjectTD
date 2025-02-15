using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    [SerializeField] private GameObject common1, common2, elite1, elite2, boss;
    [SerializeField] private int amount1, amount2, amount3, amount4, amount5;
    private List<GameObject> wave = new List<GameObject>();
    private List<int> amountToSpawn = new List<int>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        populateList();
        spawnEnemies();
        Debug.Log(wave[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnEnemies()
    {
        // get the values from the amount to spawn list 
        foreach (var enemytospawn in amountToSpawn)
        {
            // check if the value taken from the list != 0 
            if (enemytospawn != 0)
            {
                // define an int spawn x amount of enemies in relation to the amount inputted
                int j = 0;
                while (j < enemytospawn)
                {
                    Instantiate(wave[j]);
                    j++;
                }
            }
        }
    }
    

    // takes the values from the inspector and assigns it to the local variables
    void populateList()
    {
        wave.Add(common1);
        wave.Add(common2);
        wave.Add(elite1);
        
        amountToSpawn.Add(amount1);
        amountToSpawn.Add(amount2);
        amountToSpawn.Add(amount3);
        amountToSpawn.Add(amount4);
        amountToSpawn.Add(amount5);
    }
}