using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MinerScript : MonoBehaviour, IUnit, ISelectable
{
    private Vector3 Target;
    
    private bool _isSelected;
    private Selection selection;
    private Vector3 targetPile;
    private int currentCarry;
    private int maxCarry;

    [SerializeField] private NavMeshAgent agent;


    private enum State { Idle, MoveTo, Mining, DroppedOff}
    private State state;

    //#region registry
    //private void Awake()
    //{
    //    maxCarry = 5;
    //    selection = FindObjectOfType<Selection>();
    //    selection.unitList.Add(this.gameObject);
    //}

    //private void OnDestroy()
    //{
    //    selection.unitList.Remove(this.gameObject);
    //}
    //#endregion

    //#region state


    //private void Update()
    //{
    //    if (_isSelected)
    //    {
    //        if (Input.GetMouseButtonDown(1))
    //        {
    //            Debug.Log("Mouse pressed");
    //            if (findLayer() == 10)
    //            {
    //                targetPile = target;
    //                state = State.MoveToResource;
    //            }
    //            Moveto(target);
    //        }
    //    }
    //    switch (state)
    //    {
    //        case State.Idle:

    //            break;
    //        case State.MoveToResource:

    //            Debug.Log("Moving to Resource");
    //            agent.isStopped = false;
    //            if (Vector3.Distance(targetPile, transform.position) <= 5)
    //                state = State.Mining;
    //            else
    //                Moveto(targetPile);

    //            break;
    //        case State.Mining:
    //            Debug.Log("Mining");
    //            agent.isStopped = true;
    //            if (currentCarry >= maxCarry)
    //                state = State.MoveToStorage;
    //            else
    //                currentCarry++;
    //            break;
    //        case State.MoveToStorage:
    //            Debug.Log("Moving to Storage");
    //            agent.isStopped = false;
    //            if (Vector3.Distance(Storage.Instance.GetClosestStorage(transform.position).transform.position, transform.position) <= 5)
    //            {
    //                agent.isStopped = true;
    //                if (targetPile == null)
    //                    state = State.Idle;
    //                else
    //                    state = State.MoveToResource;
    //            }
    //            else
    //                Moveto(Storage.Instance.GetClosestStorage(transform.position).transform.position);
    //            break;
    //        default:
    //            break;
    //    }
    //}
    //#endregion

    //#region base


    //public void damaged()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void Deselect()
    //{
    //    _isSelected = false;
    //    this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    //}

    //public void Moveto(Vector3 target)
    //{
    //    agent.SetDestination(target);
    //}

    //public void Select()
    //{
    //    _isSelected = true;
    //    this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    //}

    //private int findLayer()
    //{
    //    int layer;

    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    Physics.Raycast(ray, out hit, Mathf.Infinity);
    //    target = hit.point;
    //    layer = hit.transform.gameObject.layer;

    //    return layer;

    //}
    //#endregion

    public void Deselect()
    {
        _isSelected = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    public void Moveto(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void Select()
    {
        _isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log("Idle");
                if (_isSelected)
                {
                    if (Mouse.current.rightButton.isPressed)
                    {
                        state = State.MoveTo;
                    }
                }
                break;
            case State.MoveTo:
                Debug.Log("MoveTo");
                agent.isStopped = false;
                if (IsDroppingOff == false)
                {
                    if (GetLayer() == 10)
                    {
                        targetPile = Target;
                        Moveto(Target);
                        if (Vector3.Distance(targetPile, transform.position) <= 20)
                        {
                            state = State.Mining;
                        }
                    }
                    else
                    {
                        Moveto(Target);
                        state = State.Idle;
                    }
                }
                else
                {
                    state = State.DroppedOff;
                }
                break;
            case State.Mining:
                Debug.Log("Mining");
                agent.isStopped = true;
                IsDroppingOff = true;
                state = State.Idle;
                break;
            case State.DroppedOff:
                Debug.Log("Full");
                IsDroppingOff = false;
                state = State.MoveTo;
                break;
            default:
                break;
        }
    }

    private bool IsDroppingOff = false;
    //{
    //    get
    //    {
    //        bool isDroppingOff = false;
    //        if (currentCarry >= maxCarry)
    //        {

    //        }
    //        return isDroppingOff;
    //    }
    //}


    private int GetLayer()
    {
        int layer;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        layer = hit.transform.gameObject.layer;
        SetTarget(hit.point);
        return layer;
    }

    private void SetTarget(Vector3 target)
    {
        Target = target;
    }

}
