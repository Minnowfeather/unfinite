using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    public BossGameStateInterpreter interpreter;
    BossMemory memory;
    BossDecisionTree tree;
    public int points;
    Coroutine currentAction;

    // Start is called before the first frame update.
    void Start()
    {
        points = 1;

        interpreter = GetComponent<BossGameStateInterpreter>();
        memory = new BossMemory(3);
        tree = new BossDecisionTree(points);
        CompileActionSpace();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecordResult(BossSequence m_sequence)
    {
        if (!m_sequence.ValidateData())
        {
            //Error
        }
        memory.Record(m_sequence);

        Activate();
    }

    List<BossAction> actions = new List<BossAction>();

    //This method finds all resources in Resources/BossActions and loads them into an array.
    //It then finds the specific type, the constructor for that class, and invokes the constructor.
    //Finally it takes the created instance and adds it to the actions list.
    public void CompileActionSpace()
    {
        actions = new List<BossAction>();

        Type[] parameters = new Type[1];
        parameters[0] = typeof(Boss);
        object[] inputs = new object[1];
        inputs[0] = this;
         
        foreach (UnityEngine.Object A in Resources.LoadAll("BossActions"))
        {
            actions.Add((BossAction)Type.GetType(A.name).GetConstructor(parameters).Invoke(inputs));
        }            
    }

    public void Terminate()
    {
        StopCoroutine(currentAction);
        Adapt();
    }

    public void Adapt()
    {

    }

    public void Activate()
    {
        GameData gameData = interpreter.InterpretGameState();
        currentAction = StartCoroutine(tree.Evaluate(gameData).Act());
    }
}
