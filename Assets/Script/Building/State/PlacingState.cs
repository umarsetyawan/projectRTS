using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingState : BaseState
{


    private GameObject _Building;

    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Building = Unit;
        Debug.Log(_Building.name);
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        _Building.transform.position = GameManager.Instance.MousePosition;
    }

    public override void TerminateState()
    {
        base.TerminateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
