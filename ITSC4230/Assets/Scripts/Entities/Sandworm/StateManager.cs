using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // SW controller component
    public SandwormController swCont;

    // States
    public BaseState currentState;
    public Idle idle = new Idle();
    public Patrol patrol = new Patrol();
    public Chase chase = new Chase();
    public Eat eat = new Eat();
    public Wait wait = new Wait();

    void Start()
    {
        // Assign SW controller component
        swCont = GetComponent<SandwormController>();

        // Set default state
        currentState = idle;

        // Enter current state
        currentState.EnterState(this);
    }

    void FixedUpdate() { // Update the state logic every frame
        currentState.UpdateState(this);
    }

    public void ChangeState(BaseState newState) {
        // Run exit method of current state
        currentState.ExitState(this);

        // Reassign current state
        currentState = newState;

        // Enter current state
        newState.EnterState(this);
    }
}
