using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MinerScript : Unit, ISelectable
{
    #region Config
    private GameManager gameManager;
    private Order order;
    private BaseState _CurrentState;
    private int _Layer;
    private Vector3 _Location;

    [SerializeField] private float MoveSpeed;

    #region public Variable

    public int MaxCarry;

    public float MineTime;

    public int Layer { get { return _Layer; } }

    public Vector3 Location { get { return _Location; } }

    [HideInInspector] public NavMeshAgent agent;

    public int CurrentCarry;


    #region State
    [HideInInspector] public BaseState Idle;
    [HideInInspector] public MoveToResource MoveToResource;
    [HideInInspector] public GatheringState Mining;
    [HideInInspector] public MoveToStorage MoveToStorage;
    [HideInInspector] public MoveToLocation FreeMove;
    #endregion
    #endregion


    private void Awake()
    {
        StateInit();

        if (_CurrentState == null)
            _CurrentState = Idle;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = MoveSpeed;
        order = FindObjectOfType<Order>();
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
    }


   



}
