using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : BaseState
{

    private int frame = 0;
    private int waitTimeFrames = 90;
    

    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
        sm.swCont.aiDest.target = sm.swCont.lastTargetTransform;
        frame = 0;
    }

    public override void UpdateState(StateManager sm) {
        base.EnterState(sm);
        frame += 1;

        if (sm.swCont.target != null) {
            sm.ChangeState(sm.chase);
        }

        if (frame >= waitTimeFrames) {
            sm.ChangeState(sm.idle);
        }

    }
    
}
