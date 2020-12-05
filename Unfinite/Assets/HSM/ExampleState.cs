using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleState : ExampleParentState
{
    public ExampleState(StateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Hello There!");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Input.GetKeyDown(KeyCode.Space)) {
            stateMachine.ChangeState("exampleState2");
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Good Bye");
    }
}
