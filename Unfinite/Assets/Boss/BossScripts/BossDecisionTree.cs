using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDecisionTree
{
    BossDecisionNode rootNode = new BossDecisionNode();

    public BossDecisionTree(int m_points)
    {
        GenerateTree(m_points);
    }

    public void GenerateTree(int m_points)
    {
        if (m_points < 2)
        {
            m_points = 2;
        }

        List<BossAction> actionSpace = new List<BossAction>();
        List<BossAction> possibleActionSpace = Boss.Current().actions;
        List<BossDecisionNode> layerNodes = new List<BossDecisionNode>();
        List<BossDecisionNode> newLayerNodes = new List<BossDecisionNode>();

        for (int i = 0; i < m_points; i++)
        {
            actionSpace.Add(possibleActionSpace[Random.Range(0, possibleActionSpace.Count)]);
        }

        foreach (BossAction action in actionSpace)
        {
            layerNodes.Add(action);
        }

        do
        {
            newLayerNodes = new List<BossDecisionNode>();

            if (layerNodes.Count % 2 == 0)
            {
                for (int i = 0; i < layerNodes.Count - 1; i += 2)
                {
                    List<BossDecisionNode> nodeSpace = BossNodeData.FindMatches(layerNodes[i], layerNodes[i + 1]);
                    BossDecisionNode node = nodeSpace[Random.Range(0, nodeSpace.Count)];
                    node.left = layerNodes[i];
                    node.right = layerNodes[i + 1];
                    newLayerNodes.Add(node);
                }

                layerNodes = newLayerNodes;
            } else
            {
                for (int i = 0; i < layerNodes.Count - 2; i += 2)
                {
                    List<BossDecisionNode> nodeSpace = BossNodeData.FindMatches(layerNodes[i], layerNodes[i + 1]);
                    BossDecisionNode node = nodeSpace[Random.Range(0, nodeSpace.Count)];
                    node.left = layerNodes[i];
                    node.right = layerNodes[i + 1];
                    newLayerNodes.Add(node);
                }

                newLayerNodes.Add(layerNodes[layerNodes.Count - 1]);
                layerNodes = newLayerNodes;                
            }

            Debug.Log(layerNodes.Count);

        } while (layerNodes.Count > 1);

        rootNode = layerNodes[0];
    }

    public BossAction Evaluate(GameData m_gameData)
    {
        return rootNode.Evaluate(m_gameData, new List<BossDecisionNode>());
    }
}
