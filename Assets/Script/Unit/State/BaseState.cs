using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "State", menuName = "State/BaseState")]
public class BaseState
{
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
