using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected readonly EconomicUnitScript _script;

    public State(EconomicUnitScript script)
    {
        _script = script;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Mining()
    {
        yield break;
    }

    public virtual IEnumerator ToStorage()
    {
        yield break;
    }

}
