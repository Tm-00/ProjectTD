using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{

    [SerializeField] 
    private Camera playerCamera;
    
    private GameObject _unit;
    
    // Update is called once per frame
    void Update()
    {
        if (_unit != null)
        {
            Ray r = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(r, out RaycastHit hitInfo, 500f))
            {
                _unit.transform.position = hitInfo.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _unit = null;
            }
        }
    }

    public void UnitToPlace(GameObject unit)
    {
        _unit = Instantiate(unit, Vector3.zero, Quaternion.identity);
    }
}
