using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class BluePrint : MonoBehaviour
{
    private float colideCount;
    private bool isRotating = false;
   

    [SerializeField] private GameObject prefab;
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject cursor;





    private void Awake()
    {
        colideCount = 0;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            transform.position = hit.point;
        }
    }

    private void Update()
    {

        

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            if (isRotating)
            {
                cursor.transform.position = hit.point;
            }
            else
            {
                transform.position = hit.point;
            }
            
        }




        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            Instantiate(cursor, transform.position, transform.rotation);

        }
        if (Input.GetMouseButton(0))
        {
            transform.transform.LookAt(new Vector3(cursor.transform.position.x, transform.position.y, cursor.transform.position.z));
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (colideCount < 1)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Colliding");
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        colideCount++;
        Debug.Log(colideCount);
    }


    private void OnTriggerExit(Collider other)
    {
        colideCount--;
        Debug.Log(colideCount);
    }


}
