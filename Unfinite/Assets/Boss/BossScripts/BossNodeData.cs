using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNodeData
{
    public List<BossNodeType> front, left, right = new List<BossNodeType>();

    public BossNodeData() { }
    public BossNodeData(List<BossNodeType> m_front, List<BossNodeType> m_left, List<BossNodeType> m_right) 
    {
        front = m_front;
        left = m_left;
        right = m_right;
    }

    public static List<BossDecisionNode> FindMatches(BossDecisionNode m_left, BossDecisionNode m_right)
    {
        List<BossDecisionNode> nodeSpace = new List<BossDecisionNode>();

        foreach (BossDecisionNode node in nodeSpace)
        {
            bool add = false;

            foreach (BossNodeType leftType in m_left.nodeData.front)
            {
                if (node.nodeData.left.Contains(leftType))
                {
                    add = true;
                }
            }

            foreach (BossNodeType rightType in m_right.nodeData.front)
            {
                if (node.nodeData.right.Contains(rightType))
                {
                    add = true;
                }
            }

            if (add)
            {
                nodeSpace.Add(node);
            }
        }

        return nodeSpace;
    }

    public static List<BossDecisionNode> nodeSpace = new List<BossDecisionNode>(new BossDecisionNode[] {
        new BossDecisionNode(BossHeuristic.Heuristic.CLOSE, new BossNodeData(new List<BossNodeType>(new BossNodeType[] {}), new List<BossNodeType>(new BossNodeType[] {}), new List<BossNodeType>(new BossNodeType[] {})))

    });
}
