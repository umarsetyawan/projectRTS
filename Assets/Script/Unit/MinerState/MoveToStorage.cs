using System.Collections;
public class MoveToStorage : State
{
    public MoveToStorage(EconomicUnitScript script) : base(script)
    {
    }

    public override IEnumerator ToStorage()
    {
        yield break;
    }
}