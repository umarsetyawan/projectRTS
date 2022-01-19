using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//[RequireComponent(typeof(Rigidbody))]

public class Blueprint : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private LayerMask ground;
    private Vector3 direction;
    private float colideCount;
    private Vector3 lastMousePosition;

    private enum State { positioning, rotating, placement}
    private State state;


    private void Awake()
    {
    }


    private void Update()
    {
        switch (state)
        {
            case State.positioning:
                if (Mouse.current.leftButton.isPressed)
                {
                    if (lastMousePosition != Input.mousePosition)
                        state = State.rotating;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    state = State.placement;
                }
                transform.position = GetMousePos();
                lastMousePosition = Input.mousePosition;
                break;
            case State.rotating:
                if (Input.GetMouseButton(0))
                    SetDirection();
                if (Input.GetMouseButtonUp(0))
                    state = State.placement;
                break;
            case State.placement:
                if (colideCount > 0)
                {
                    Debug.Log("Colliding");
                    state = State.positioning;
                }
                else 
                {
                    prefab.GetComponent<StorageBuilding>().Build(transform.position, transform.rotation);
                    colideCount = 0;
                    state = State.positioning;
                    GameObject.Destroy(this.gameObject);
                    Camera.main.GetComponent<DragSelect>().enabled = true;
                }
                break;
            default:
                break;
        }
    }

    private Vector3 GetMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, ground);
        return hit.point;
    }

    private void SetDirection()
    {
        #region determine mouse position
        Vector3 _dir = Vector3.zero;
        direction = GetMousePos() - transform.position;
        _dir = direction.normalized;

        if (_dir.x <= -0.5)
        {
            Debug.Log("Left");
            Quaternion yawRotation = Quaternion.AngleAxis(-90f, Vector3.up);
            transform.rotation = yawRotation;
        }
        if (_dir.x >= 0.5)
        {
            Debug.Log("Right");
            Quaternion yawRotation = Quaternion.AngleAxis(90f, Vector3.up);
            transform.rotation = yawRotation;
        }
        if (_dir.z <= -0.5)
        {
            Debug.Log("down");
            Quaternion yawRotation = Quaternion.AngleAxis(180f, Vector3.up);
            transform.rotation = yawRotation;
        }
        if (_dir.z >= 0.5)
        {
            Debug.Log("Up");
            Quaternion yawRotation = Quaternion.AngleAxis(0f, Vector3.up);
            transform.rotation = yawRotation;
        }
        #endregion


    }

    private void PlaceBuilding()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
        colideCount++;
    }


    private void OnTriggerExit(Collider other)
    {
        colideCount--;
    }


}
