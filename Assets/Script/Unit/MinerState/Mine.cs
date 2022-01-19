using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Unit.MinerState
{
    public class Mine : State
    {
        

        public Mine(EconomicUnitScript script) : base(script)
        {
        }

        public override IEnumerator Mining()
        {
            if (_script.currentCarry >= _script.maxCarry)
            {
                _script.SetState(new MoveToStorage(_script));
            }
            yield return new WaitForSeconds(_script.mineTime);
            _script.currentCarry += 1;
        }
    }
}