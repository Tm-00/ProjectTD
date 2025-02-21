using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TowerPlacement : MonoBehaviour
{

    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask placementCollideMask;
    [SerializeField] private LayerMask placementCheckMask;
    public static GameObject unit;
    private int totalUnits = 0;
    
    
    // Update is called once per frame
    void Update()
    {
        if (unit != null)
        {
            Ray r = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(r, out  hitInfo, 100f, placementCollideMask))
            {
                unit.transform.position = hitInfo.point;
            }

            if (Input.GetMouseButtonDown(0) && hitInfo.collider.gameObject != null)
            {
                if (hitInfo.collider.gameObject.CompareTag("CanPlace"))
                {
                    BoxCollider unitCollider = unit.gameObject.GetComponent<BoxCollider>();
                    unitCollider.isTrigger = true;
                    
                    Vector3 BoxCenter = unit.gameObject.transform.position + unitCollider.center;
                    Vector3 HalfExtents = unitCollider.size / 2;
                    
                    totalUnits++;
                    UnitTracker.currentUnitsSpawned = totalUnits;
                    
                    if (Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, placementCheckMask, QueryTriggerInteraction.Ignore))
                    {
                        unitCollider.isTrigger = true;
                        totalUnits++;
                        UnitTracker.currentUnitsSpawned = totalUnits;
                    }
                    else
                    {
                        unitCollider.isTrigger = false;
                        unit = null;
                    }
                }
            }
        }
    }

    public void UnitToPlace(GameObject unit1)
    {
        unit = ObjectPoolManager.SpawnObject(unit1, Vector3.zero, Quaternion.identity, ObjectPoolManager.PoolType.playerUnits);
    }
}
