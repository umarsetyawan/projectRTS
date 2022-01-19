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

    #endregion


    private Selection selection;
    private State _currentState;

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


    private void Awake()
    {
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
        if (Input.GetMouseButtonDown(1))
        {

        }
    }


    public void SetState(State state)
    {
        _currentState = state;
        StartCoroutine(_currentState.Start());
    }

}
