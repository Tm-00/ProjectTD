using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTracker : MonoBehaviour
{
    
    public List<GameObject> navMeshTargets = new List<GameObject>();
    [SerializeField] private GameObject coreNode;
    //private Transform coreNodePosition;

    private int i;
    private int currentUnitsSpawned;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //coreNodePosition = coreNode.transform;
        navMeshTargets.Insert(0, coreNode);

        TowerPlacement tp = gameObject.AddComponent<TowerPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentUnitsSpawned = TowerPlacement.totalUnits;
        if (UnitsSpawned())
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FloorUnit"))
            {
                navMeshTargets.Add(obj);
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("WallUnit"))
            {
                navMeshTargets.Add(obj);
            }
        }
    }

    private bool UnitsSpawned()
    {
        if (i < currentUnitsSpawned)
        {
            return true;
        }
        return false;
    }
}
