using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : BaseState
{
    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
    }

    public override void UpdateState(StateManager sm) {
        base.UpdateState(sm);

        sm.ChangeState(sm.wait);
    }
}
