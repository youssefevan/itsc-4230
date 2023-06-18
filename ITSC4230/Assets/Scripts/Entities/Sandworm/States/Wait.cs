using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : BaseState
{

    // Timer
    private int frame = 0;
    private int waitTimeFrames = 90;
    

    public override void EnterState(StateManager sm) {
        base.EnterState(sm);

        // When the target exits it's range (or is disabeled), the SW controller will
        // update lastTargetTransfrom to the last known location of the target.
        // Therefore, the line below tells the worm to go to the last known position
        // of the target.
        sm.swCont.aiDest.target = sm.swCont.lastTargetTransform;

        // Reset timer
        frame = 0;
    }

    public override void UpdateState(StateManager sm) {
        base.EnterState(sm);

        // keep track of frames
        frame += 1;

        // Chase target if exists
        if (sm.swCont.target != null) {
            sm.ChangeState(sm.chase);
        }

        // Return to idle when timer ends 
        if (frame >= waitTimeFrames) {
            sm.ChangeState(sm.idle);
        }

        // Change to eat state if eatTarget exists
        if (sm.swCont.eatTarget != null) {
            sm.ChangeState(sm.eat);
        }

    }
    
}
