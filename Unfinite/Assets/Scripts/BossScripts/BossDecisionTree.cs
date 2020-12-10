using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDecisionTree
{
    BossDecisionNode rootNode = new BossDecisionNode("None");

    public BossDecisionTree(int m_points)
    {
        GenerateTree(m_points);
    }

    public void GenerateTree(int m_points)
    {

    }

    public BossAction Evaluate(GameData m_gameData)
    {
        return rootNode.Evaluate(m_gameData);
    }
}
