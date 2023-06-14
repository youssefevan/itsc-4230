using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public virtual void EnterState(StateManager sm){
        //Debug.Log(sm.currentState);
    }
    
    public virtual void UpdateState(StateManager sm){}
    public virtual void OnCollisionEnter2D(StateManager sm){}
    public virtual void ExitState(StateManager sm){}
}
