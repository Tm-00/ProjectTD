using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);
        
        
        // if the pool doesn't exist create it
        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        // check for inactive objects in pool
        GameObject SpawnableObj = pool.InactiveObjects.FirstOrDefault();

        if (SpawnableObj == null)
        {
            // if there are no inactive objects create a new one
            SpawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        }
        else
        {
            // if there is and inactive object reactivate it
            SpawnableObj.transform.position = spawnPosition;
            SpawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(SpawnableObj);
            SpawnableObj.SetActive(true);
        }
        return SpawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        // removes the clone from the name passed in obj
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == obj.name);

        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}