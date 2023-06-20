using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : BaseState
{

    private int frame = 0;
    private int eatTimeFrames = 120;

    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
        frame = 0;
        sm.swCont.foundFood = false;
    }

    public override void UpdateState(StateManager sm) {
        base.UpdateState(sm);
        frame += 1;

        if (frame >= eatTimeFrames) {
            sm.ChangeState(sm.idle);
        }
    }
}
