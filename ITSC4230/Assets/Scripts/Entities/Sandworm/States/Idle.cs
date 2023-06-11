using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
        sm.swCont.target = sm.swCont.territory;
    }

    public override void UpdateState(StateManager sm) {
        base.UpdateState(sm);
        
        sm.swCont.aiDest.target = sm.swCont.target.transform;
        
        if (sm.swCont.target != sm.swCont.territory) {
            sm.ChangeState(sm.chase);
        }
    }
}
