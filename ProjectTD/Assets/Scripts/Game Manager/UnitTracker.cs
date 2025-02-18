using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitTracker : MonoBehaviour
{
    
    public static List<GameObject> UnitTargets = new List<GameObject>();
    [SerializeField] private GameObject coreNode;

    private int i;
    public static int currentUnitsSpawned;
    
   
    
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
    
    public static GameObject FindClosestEnemy(NavMeshAgent nav)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("WallUnit"); 
        GameObject closestTarget = null;
        float distance = Mathf.Infinity;
        Vector3 position = nav.transform.position;
        foreach (GameObject go in gos)
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
