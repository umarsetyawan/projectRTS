using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "State", menuName = "State/AttackState")]
public class AttackStateSO : BaseState
{
    [SerializeField]private GameObject _Target;
    [SerializeField]private int _AttackDamage;
    [SerializeField]private int _AttackSpeed;
    [SerializeField]private int _AttackRange;
    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
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
