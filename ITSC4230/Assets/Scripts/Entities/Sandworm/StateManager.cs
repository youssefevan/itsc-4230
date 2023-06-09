using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public SandwormController swCont;

    public BaseState currentState;
    public Idle idle = new Idle();
    public Patrol patrol = new Patrol();
    public Chase chase = new Chase();
    public Eat eat = new Eat();
    public Wait wait = new Wait();

    void Start()
    {
        swCont = GetComponent<SandwormController>();
        currentState = idle;
        currentState.EnterState(this);
    }

    void FixedUpdate() {
        currentState.UpdateState(this);
    }

    public void ChangeState(BaseState newState) {
        currentState.ExitState(this);
        currentState = newState;
        newState.EnterState(this);
    }
}
