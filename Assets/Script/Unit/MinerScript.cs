using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MinerScript : MonoBehaviour, ISelectable
{
    #region Config
    private Selection selection;
    private bool _isSelected;
    private Order order;
    private BaseStateSO _CurrentState;
    private int _Layer;
    private Vector3 _Location;

    [SerializeField] private float MoveSpeed;

    #region public Variable

    [SerializeField] public int MaxCarry;

    public int Layer { get { return _Layer; } }

    public Vector3 Location { get { return _Location; } }

    [HideInInspector] public NavMeshAgent agent;

    public int CurrentCarry;


    #region State
    public BaseStateSO Idle;
    public BaseStateSO MoveToResource;
    public BaseStateSO Mining;
    public BaseStateSO MoveToStorage;
    public BaseStateSO FreeMove;
    #endregion
    #endregion


    private void Awake()
    {
        
        if (_CurrentState == null)
            _CurrentState = Idle;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = MoveSpeed;
        order = new Order();
        selection = FindObjectOfType<Selection>();
        selection.unitList.Add(this.gameObject);
    }


    private void OnDestroy()
    {
        selection.unitList.Remove(this.gameObject);
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

    #region Get and Set function
    public void SetState(BaseStateSO targetState)
    {
        _CurrentState.ExitState();
        _CurrentState = targetState;
        _CurrentState.StartState(this.gameObject);
    }

    private void GetOrder()
    {
        order.GetLocationAndLayer();
        _Layer = order.Layer;
        _Location = order.Location;
    }
    #endregion


    private void Update()
    {
        
        if (Mouse.current.rightButton.isPressed)
        {
            GetOrder();
            if (_isSelected)
            {
                switch (_Layer)
                {
                    case 7:
                        SetState(FreeMove);
                        break;
                    case 10:
                        SetState(MoveToResource);
                        break;
                    default:
                        break;
                }
            }
        }
        _CurrentState.UpdateState(Time.deltaTime);
        Debug.Log(gameObject.name +" "+ _CurrentState.Name);
    }


   



}
