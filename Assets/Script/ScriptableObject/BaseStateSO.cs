using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "State/BaseState")]
public class BaseStateSO : ScriptableObject
{
    [SerializeField]private string _Name;
    public string Name { get { return _Name; } }

    public virtual void StartState(GameObject Unit)
    {

    }

    public virtual void UpdateState(float DeltaTime)
    {

    }

    public virtual void TerminateState()
    {

    }

    public virtual void ExitState()
    {

    }

}
