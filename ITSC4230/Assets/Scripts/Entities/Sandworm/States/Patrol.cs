using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BaseState // *Captured* state
{
    // For keeping track of time 
    private int frame;
    private int timeFrames = 60;

    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
        frame = 0; // Reset time

        // In the worm controller, the territoy will be set to the trasform of the pen
        sm.swCont.target = sm.swCont.territory;

        // Disable the worm's vibration detection
        sm.swCont.vibrationCollider.enabled = false;
    }

    public override void UpdateState(StateManager sm) {
        // Not including the super method so it doesn't reset state

        // Start timer
        frame += 1;

        // Delete after timer is up
        if (frame >= timeFrames) {
            sm.swCont.Die();
        }
    }

}
