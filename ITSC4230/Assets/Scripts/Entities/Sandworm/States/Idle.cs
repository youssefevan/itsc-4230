using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    public override void EnterState(StateManager sm) {
        base.EnterState(sm);
        Debug.Log("test");
    }
}
