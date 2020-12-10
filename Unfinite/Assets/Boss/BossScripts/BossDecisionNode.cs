﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDecisionNode
{
    BossHeuristic.Heuristic heuristic;
    public BossDecisionNode left, right;
    BossSequence sequence;
    public BossNodeData nodeData;

    public void SetSequence(BossSequence m_sequence)
    {
        sequence = m_sequence;
    }

    public BossSequence GetSequence()
    {
        return sequence;
    }

    //Checks to see if the node is an action.
    public bool IsAction()
    {
        if (heuristic == BossHeuristic.Heuristic.NONE)
        {
            return true;
        } else
        {
            return false;
        }
    }

    //A constructor to create a new node.
    //Pass None to specify it as an action.
    public BossDecisionNode() { }

    public BossDecisionNode(BossHeuristic.Heuristic m_heursitic, BossNodeData m_nodeData) 
    {
        heuristic = m_heursitic;
        nodeData = m_nodeData;    
    }

    //Recursively computes the correct action via flowdown of the DecisionTree.
    public BossAction Evaluate(GameData m_gameData)
    {
        if (BossHeuristic.Evaluate(m_gameData, heuristic))
        {
            if (left.IsAction())
            {
                left.SetSequence(new BossSequence(m_gameData, (BossAction)left, null));
                return (BossAction)left;
            }
            return left.Evaluate(m_gameData);
        } else
        {
            if (right.IsAction())
            {
                right.SetSequence(new BossSequence(m_gameData, (BossAction)right, null));
                return (BossAction)right;
            }
            return right.Evaluate(m_gameData);
        }
    }    
}
