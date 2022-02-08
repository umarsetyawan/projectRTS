using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "State", menuName = "State/GatheringState")]
public class GatheringState : BaseState
{

    private GameObject _Unit;
    private MinerScript _Miner;

    private float _CurrentTime;

    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Unit = Unit;
        _Miner = _Unit.GetComponent<MinerScript>();
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        _CurrentTime += DeltaTime;
        if (_Miner.CurrentCarry < _Miner.MaxCarry)
        {
            if (_CurrentTime >= _Miner.MineTime)
            {
                _Miner.CurrentCarry++;
                _CurrentTime = 0;
            }
        }
        else
        {
            _CurrentTime = 0;
            _Miner.SetState(_Miner.MoveToStorage);
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
