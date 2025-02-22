using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitTracker : MonoBehaviour
{
    
    public static readonly List<GameObject> UnitTargets = new List<GameObject>();
    public static readonly List<GameObject> EnemyTargets = new List<GameObject>();
    [SerializeField] private GameObject coreNode;

    private int i;
    public static int currentUnitsSpawned;
    public static int currentEnemiesSpawned;
    public static GameObject[] unitArray;
    public static GameObject[] enemyArray;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        //coreNodePosition = coreNode.transform;
        UnitTargets.Insert(0, coreNode);
    }

    // Update is called once per frame
    void Update()
    {
        if (UnitsSpawned())
        {
            UnitTargets.Add(TowerPlacement.unit);
        }
        
        if (EnemiesSpawned())
        {
            EnemyTargets.Add(spawner.Enemy);
        }
    }

    private bool UnitsSpawned()
    {
        if (i < currentUnitsSpawned)
        {
            //Debug.Log("i =" + i);
            i = currentUnitsSpawned;
            //Debug.Log("current units" + currentUnitsSpawned + "i" + i);
            //Debug.Log(UnitTargets.Count);
            return true;
        }
        return false;
    }
    
    private bool EnemiesSpawned()
    {
        if (i < currentEnemiesSpawned)
        {
            //Debug.Log("i =" + i);
            i = currentEnemiesSpawned;
            //Debug.Log("current units" + currentUnitsSpawned + "i" + i);
            //Debug.Log(UnitTargets.Count);
            return true;
        }
        return false;
    }
    
    //TODO add another parameter that checks for the type of object accessing the method then create the array based on that e.g. rifle drone asks for lane units others ask for wall units 
    public static GameObject FindClosestWallUnit(NavMeshAgent nav)
    {
        unitArray = GameObject.FindGameObjectsWithTag("WallUnit"); 
        GameObject closestTarget = null;
        float distance = Mathf.Infinity;
        Vector3 position = nav.transform.position;
        foreach (GameObject go in unitArray)
        {
            Vector3 distanceDifference = go.transform.position - position;
            float currentDistance = distanceDifference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closestTarget = go;
                distance = currentDistance;
            }
        }
        return closestTarget;
    }
    
    public static GameObject FindClosestEnemey(GameObject goGameObject)
    {
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy"); 
        GameObject closestTarget = null;
        float distance = Mathf.Infinity;
        Vector3 position = goGameObject.transform.position;
        foreach (GameObject go in enemyArray)
        {
            Vector3 distanceDifference = go.transform.position - position;
            float currentDistance = distanceDifference.sqrMagnitude;
            if (currentDistance < distance)
            {
                closestTarget = go;
                distance = currentDistance;
            }
        }
        return closestTarget;
    }
    
}
