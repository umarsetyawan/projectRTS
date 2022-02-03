using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "State/GatheringState")]
public class GatheringStateSO : BaseStateSO
{

    private GameObject _Unit;
    private MinerScript _Miner;

    private int _CurrentCarry;
    private int _MaxCarry;

    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Unit = Unit;
        _Miner = _Unit.GetComponent<MinerScript>();
        _CurrentCarry = _Miner.CurrentCarry;
        _MaxCarry = _Miner.MaxCarry;
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        if (_Miner.CurrentCarry < _MaxCarry)
        {
            _Miner.CurrentCarry++;
        }
            
        else
            _Miner.SetState(_Miner.MoveToStorage);
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
