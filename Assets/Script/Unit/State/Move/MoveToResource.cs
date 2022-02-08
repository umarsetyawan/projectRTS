using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "State", menuName = "State/Movement State/Move to Resource")]
public class MoveToResource : BaseState
{

    private Vector3 Destination;

    private GameObject _Unit;
    private MinerScript _Miner;

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
            if (Vector3.Distance(Destination, _Unit.transform.position) <= 5)
            {
                _Miner.agent.isStopped = true;
                _Miner.SetState(_Miner.Mining);

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
