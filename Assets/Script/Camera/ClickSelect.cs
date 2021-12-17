using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask unitLayer;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, unitLayer))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Selection.Instance.shiftClickSelect(hit.transform.gameObject);
                }
                else
                {
                    Selection.Instance.clickSelect(hit.transform.gameObject);
                }
                
            }
            else
                Selection.Instance.deselectAll();
        }
        
        



    }
}
