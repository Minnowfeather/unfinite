using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the super class for every state in every state machine.
//Only add to this class if you want to add behavior to every state.
public class State
{
    public StateMachine stateMachine;

    //This is the constructor for the super class, use 
    //public <subclass name>(StateMachine stateMachine) : base(stateMachine) {}
    //in the States you implement
    public State(StateMachine _stateMachine) {
        stateMachine = _stateMachine;
    }

    //This method is called when this state is entered
    public virtual void Enter() {
        //Add base.Enter(); to methods that overrite this method
    }

    //This method is called on Update() before LogicUpdate()
    public virtual void HandleInput() {
        //Add base.HandleInput(); to methods that overrite this method
    }

    //This method is called on Update() after HandleInput()
    public virtual void LogicUpdate() {
        //Add base.LogicUpdate(); to methods that overrite this method
    }

    //This method is called on FixedUpdate()
    public virtual void PhysicsUpdate() {
        //Add base.PhysicsUpdate(); to methods that overrite this method
    }

    //This method is called when the state is exited
    public virtual void Exit() {
        //Add base.Exit(); to methods that overrite this method
    }
}
