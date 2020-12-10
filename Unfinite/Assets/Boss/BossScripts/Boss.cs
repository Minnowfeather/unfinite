using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public BossGameStateInterpreter interpreter;
    BossMemory memory;
    BossDecisionTree tree;
    public int points = 2;
    Coroutine currentAction;
    int health;

    public static Boss Current()
    {
        return GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    // Start is called before the first frame update.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        CompileActionSpace();
        interpreter = GetComponent<BossGameStateInterpreter>();
        memory = new BossMemory(3);
        tree = new BossDecisionTree(points);
        memory.NewGame();
    }

    public void ReActivate()
    {
        CompileActionSpace();
        memory.NewGame();
    }

    public int GetHealth()
    {
        return health;
    }

    public void RecordResult(BossSequence m_sequence)
    {
        if (!m_sequence.ValidateData())
        {
            //Error
        }
        memory.Record(m_sequence);

        NextAction();
    }

    public List<BossAction> actions = new List<BossAction>();

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

    const float WEIGHTCHANGE = 0.1f;

    public void Adapt()
    {
        //==TODO==
        //Implement mutation algorithm
        //This will need to evaluate which actions achieved the best results, then tune the decisionNode's heuristics to better suit the actions

        //Currently it just regenrates the tree to cause a tactic change
        tree.GenerateTree(points);

        //Mutate

        //Adapt
        List<BossSequence> sequences = memory.Read();
        foreach (BossSequence sequence in sequences)
        {
            if (BossHeuristic.Evaluate(sequence))
            {
                foreach (BossDecisionNode node in sequence.path)
                {
                    if (node.heuristic == BossHeuristic.Heuristic.WEIGHTED)
                    {
                        node.weight += WEIGHTCHANGE;
                    }
                }
            }
        }
    }

    public void NextAction()
    {
        GameData gameData = interpreter.InterpretGameState();
        currentAction = StartCoroutine(tree.Evaluate(gameData).Act());
    }
}
