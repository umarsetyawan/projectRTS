using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "State", menuName = "State/Movement State/Move")]

public class MoveToLocation : BaseState
{


    private GameObject _Unit;
    private MinerScript _Miner;
    private Vector3 Destination;

    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Unit = Unit;
        _Miner = _Unit.GetComponent<MinerScript>();
        Destination = _Miner.Location;
        _Miner.agent.isStopped = false;

    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        _Miner.agent.SetDestination(Destination);
        if (Vector3.Distance(Destination, _Miner.transform.position) < 1)
        {
            _Miner.SetState(_Miner.Idle);
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
