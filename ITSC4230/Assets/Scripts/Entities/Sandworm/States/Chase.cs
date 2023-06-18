using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : BaseState
{

    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
    }

    public override void UpdateState(StateManager sm) {
        base.UpdateState(sm);

        if (sm.swCont.target != null) {
            sm.swCont.aiDest.target = sm.swCont.target.transform;
            sm.swCont.lastTargetTransform = sm.swCont.target.transform;
        } else {
            sm.ChangeState(sm.wait);
        }

        if (sm.swCont.foundFood == true) {
            sm.ChangeState(sm.eat);
        }
    }
}
