using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EconomicUnitScript : MonoBehaviour, IUnit, ISelectable
{
    #region public variabel
    public float mineTime;
    public int currentCarry;
    public int maxCarry;
    public Vector3 closestStorageLocation { get; private set; }

    #endregion


    private Selection selection;
    private Storage storage;
    private int layer;
    private Vector3 destination;


    #region Interface Implementation

    private bool _isSelected = false;
    private NavMeshAgent agent;

    public void Moveto(Vector3 target)
    {
        agent.SetDestination(target);
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        layer = hit.transform.gameObject.layer;
        return hit.point;

    }

    public void Select()
    {
        _isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void Deselect()
    {
        _isSelected = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }
    #endregion

    private enum State { Idle, MoveToResource, Mining, MoveToStorage, FreeMove }
    private State state;
    private void Awake()
    {
        storage = GetComponent<Storage>();
        agent = GetComponent<NavMeshAgent>();
        selection = FindObjectOfType<Selection>();
        selection.unitList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        selection.unitList.Remove(this.gameObject);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                Debug.Log("Idle");
                if (Input.GetMouseButtonDown(1) && _isSelected)
                {
                    destination = GetMousePosition();
                    Debug.Log(layer);
                    if (layer == 10)
                    {
                        state = State.MoveToResource;
                    }
                    else
                    {
                        state = State.FreeMove;
                    }
                }
                    
                break;
            case State.MoveToResource:
                Debug.Log("Move to resource");
                if (Input.GetMouseButtonDown(1) && _isSelected)
                    state = State.FreeMove;
                else
                {
                    Moveto(destination);
                    if (layer == 10 && Vector3.Distance(destination, transform.position) <= 20)
                    {
                        state = State.Mining;
                    }
                    
                    
                }
                break;
            case State.Mining:
                Debug.Log("Mining");
                if (Input.GetMouseButtonDown(1) && _isSelected)
                    state = State.FreeMove;
                else
                {
                    if (currentCarry >= maxCarry)
                    {
                        state = State.MoveToStorage;
                    }
                    else
                        currentCarry++;
                }
                break;
            case State.MoveToStorage:
                Debug.Log("Move to storage");
                if (Input.GetMouseButtonDown(1) && _isSelected)
                    state = State.FreeMove;
                else
                {

                }
                break;
            case State.FreeMove:
                Debug.Log("FreeMove");
                state = State.Idle;
                break;
            default:
                break;
        }
    }
}