using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleState2 : ExampleParentState
{
    public ExampleState2(StateMachine stateMachine) : base(stateMachine) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("AAAA");
    }
}
