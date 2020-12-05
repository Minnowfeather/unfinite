using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleParentState : State
{
    public ExampleParentState(StateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Im an example");
    }
}
