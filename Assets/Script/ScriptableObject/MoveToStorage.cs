using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "State/Movement State/Move to Storage")]
public class MoveToStorage : BaseStateSO
{
    private GameObject _ClosestStorage;
    private Vector3 _StorageLocation;
    private GameObject _Unit;
    private MinerScript _Miner;


    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Unit = Unit;
        _Miner = _Unit.GetComponent<MinerScript>();
        if (Storage.Instance.Storages.Count > 0)
        {
            _ClosestStorage = Storage.Instance.GetClosestStorage(_Miner.transform.position);
            _StorageLocation = _ClosestStorage.transform.position;
        }
        else
            _Miner.SetState(_Miner.Idle);
        
        _Miner.agent.isStopped = false;
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        _Miner.agent.SetDestination(_StorageLocation);
        if (Vector3.Distance(_StorageLocation, _Miner.transform.position) < 10)
        {
            _Miner.CurrentCarry = 0;
            _Miner.SetState(_Miner.MoveToResource);
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
