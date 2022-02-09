using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionState : BaseState
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
        Debug.Log("Constructing");
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
