using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public virtual void EnterState(StateManager sm) { // Runs once when entering state
        //Debug.Log(sm.currentState);
    }
    
    public virtual void UpdateState(StateManager sm) { // Runs every frame
        // Check to see if the worm is captured
        if (sm.swCont.captured == true) {
            sm.ChangeState(sm.patrol); // "Patrol" state is actually the capture state
        }
    }

    public virtual void OnCollisionEnter2D(StateManager sm){} // Checks for collisions

    public virtual void ExitState(StateManager sm){} // Runs once when exiting states
}
