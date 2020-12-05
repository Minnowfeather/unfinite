using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This is the super class for any state machine.
//Note it implements monobehavior as StateMachines
//should be added to a gameObject
public class StateMachine : MonoBehaviour
{
    //This variable holds the current state of the state machine
    State currentState;

    //This is the regular Update() method to call HandleInput() and LogicUpdate()
    void Update()
    {
        currentState.HandleInput();
        currentState.LogicUpdate();
    }

    //This is the regular FixedUpdate() to call PhysicsUpdate()
    void FixedUpdate() {
        currentState.PhysicsUpdate();
    }

    //This is the Initialize method, use it in the Start() method
    //of classes which implement StateMachine
    public void Initialize(State startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    //This is the ChangeState method, used to have the StateMachine
    //change states by passing a string representing the name of the new
    //state as implemented in theStateMachine
    public void ChangeState(string stateName) {
        State newState = (State) this.GetType().GetField(stateName).GetValue(this);

        currentState.Exit();
        currentState = newState;
        newState.Enter();
    }

    public T getField<T>(string fieldName) {
        return (T) this.GetType().GetField(fieldName).GetValue(this);
    }
}
