using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSequence
{
    public GameData preActionData;
    public List<BossDecisionNode> path;
    public GameData postActionData;

    public BossSequence(GameData m_preActionData, List<BossDecisionNode> m_path, GameData m_postActionData)
    {
        preActionData = m_preActionData;
        path = m_path;
        postActionData = m_postActionData;
    }

    public bool ValidateData()
    {
        if (preActionData == null || path == null || postActionData == null)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
