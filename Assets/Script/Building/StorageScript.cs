using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StorageScript : Building
{

    #region Public Variable
    public BaseState _CurrentState;


    #region State
    public BaseState Placed;
    public PlacingState Placing;
    public RotatingState Rotating;
    public ConstructionState Construction;
    #endregion
    #endregion

    private void StateInit()
    {
        Placed = new BaseState();
        Placing = new PlacingState();
        Rotating = new RotatingState();
        Construction = new ConstructionState();
    }


    private void Awake()
    {
        StateInit();
        if (_CurrentState == null)
            _CurrentState = Placing;
        SetState(Placing);
        GameManager.Instance.Storages.Add(gameObject);
    }

    #region Get and Set Function

    public void SetState(BaseState NewState)
    {
        _CurrentState.ExitState();
        _CurrentState = NewState;
        _CurrentState.StartState(this.gameObject);
    }

    
        #endregion


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetState(Rotating);
        }
        if (Input.GetMouseButtonUp(0))
        {
            SetState(Construction);
            Camera.main.GetComponent<DragSelect>().enabled = true;
        }
        _CurrentState.UpdateState(Time.deltaTime);
    }

    public override void OnBuild()
    {
        base.OnBuild();
    }

    public override void OnFinnished()
    {
        IsFinnished = true;
    }
}
