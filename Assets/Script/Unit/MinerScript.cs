using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MinerScript : Unit, ISelectable
{
    #region Config
    private GameManager gameManager;
    private Order.OrderType _Order;
    private BaseState _CurrentState;
    private int _Layer;
    private Vector3 _Location;

    [SerializeField] private float MoveSpeed;

    #region public Variable

    public int MaxCarry;

    public float MineTime;

    public int Layer { get { return _Layer; } }
    public Order.OrderType Orders { get { return _Order; } set { _Order = value; } }

    public Vector3 Location { get { return _Location; } }

    [HideInInspector] public NavMeshAgent agent;

    public int CurrentCarry;


    #region State
    public BaseState Idle;
    public MoveToResource MoveToResource;
    public GatheringState Mining;
    public MoveToStorage MoveToStorage;
    public MoveToLocation FreeMove;
    public BuildingState Build;
    #endregion
    #endregion


    private void Awake()
    {
        StateInit();

        if (_CurrentState == null)
            _CurrentState = Idle;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = MoveSpeed;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.unitList.Add(this.gameObject);
    }

    private void StateInit()
    {
        Idle = /*ScriptableObject.CreateInstance<BaseStateSO>()*/ new BaseState();
        MoveToResource = /*ScriptableObject.CreateInstance<MoveToResourceSO>()*/new MoveToResource();
        Mining = /*ScriptableObject.CreateInstance<GatheringStateSO>()*/new GatheringState();
        MoveToStorage = /*ScriptableObject.CreateInstance<MoveToStorageSO>()*/new MoveToStorage();
        FreeMove = /*ScriptableObject.CreateInstance<MoveToLocationSO>()*/new MoveToLocation();
        Build = new BuildingState();
    }


    private void OnDestroy()
    {
        gameManager.unitList.Remove(this.gameObject);
    }

    //public void Select()
    //{
    //    _isSelected = true;
    //    this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    //}

    //public void Deselect()
    //{
    //    _isSelected = false;
    //    this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    //}
    #endregion

    #region Get and Set function
    public void SetState(BaseState targetState)
    {
        _CurrentState.ExitState();
        _CurrentState = targetState;
        _CurrentState.StartState(this.gameObject);
    }

    private void GetOrder()
    {
        Order.Instance.SetOrder();
        _Order = Order.Instance.TheOrder;
        _Layer = Order.Instance.Layer;
        _Location = Order.Instance.Location;
    }
    #endregion


    private void Update()
    {
        Debug.Log(_CurrentState);
        _CurrentState.UpdateState(Time.deltaTime);
        if (Mouse.current.rightButton.isPressed)
        {
            //GetOrder();
            if (_isSelected)
            {
                GetOrder();
                switch (_Order)
                {
                    case Order.OrderType.Idle:
                        SetState(Idle);
                        _CurrentState.UpdateState(Time.deltaTime);
                        break;
                    case Order.OrderType.Mining:
                        SetState(MoveToResource);
                        _CurrentState.UpdateState(Time.deltaTime);
                        break;
                    case Order.OrderType.Building:
                        SetState(Build);
                        _CurrentState.UpdateState(Time.deltaTime);
                        break;
                    case Order.OrderType.Moving:
                        SetState(FreeMove);
                        _CurrentState.UpdateState(Time.deltaTime);
                        break;
                    case Order.OrderType.Attacking:
                        _CurrentState.UpdateState(Time.deltaTime);
                        break;
                    default:
                        Debug.Log("Empty");
                        break;
                }
            }
                
        }
        

    }


   



}
