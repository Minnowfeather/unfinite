using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSequence
{
    public GameData preActionData;
    public BossAction action;
    public GameData postActionData;

    public BossSequence(GameData m_preActionData, BossAction m_action, GameData m_postActionData)
    {
        preActionData = m_preActionData;
        action = m_action;
        postActionData = m_postActionData;
    }

    public bool ValidateData()
    {
        if (preActionData == null || action == null || postActionData == null)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
