using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTracker : MonoBehaviour
{
    
    public static List<GameObject> UnitTargets = new List<GameObject>();
    [SerializeField] private GameObject coreNode;
    //private Transform coreNodePosition;

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
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("FloorUnit"))
            {
                UnitTargets.Add(obj);
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("WallUnit"))
            {
                UnitTargets.Add(obj);
            }
        }
    }

    private bool UnitsSpawned()
    {
        if (i < currentUnitsSpawned)
        {
            //Debug.Log("i =" + i);
            i = currentUnitsSpawned;
            //Debug.Log("current units" + currentUnitsSpawned + "i" + i);
            return true;
        }
        return false;
    }
}
