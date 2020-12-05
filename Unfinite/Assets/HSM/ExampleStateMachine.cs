using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleStateMachine : StateMachine
{
    public ExampleState2 exampleState2;
    public ExampleState exampleState;

    // Start is called before the first frame update
    void Start()
    {
        exampleState = new ExampleState(this);
        exampleState2 = new ExampleState2(this);
        Initialize(exampleState);
    }

}
