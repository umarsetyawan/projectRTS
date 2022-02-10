using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionState : BaseState
{

    private GameObject _Building;
    private int _Progress;
    private float _BuiltTime = 0.5f;
    private float _CurrentTime;
    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Building = Unit;
        Debug.Log(_Building.name);
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        Debug.Log(_Progress);
        _CurrentTime += DeltaTime;
        if (_Progress < 100)
        {
            if (_CurrentTime >= _BuiltTime)
            {
                _Progress++;
                _CurrentTime = 0;
            }
        }
        else
        {
            Debug.Log("Finnished Construction");
        }
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
