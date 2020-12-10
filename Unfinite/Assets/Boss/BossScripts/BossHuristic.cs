using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BossHeuristic
{
    public enum Heuristic
    {
        NONE,
        WEIGHTED,
        CLOSE
    }

    const int CLOSERANGE = 1;

    public static bool Evaluate(BossSequence m_sequence)
    {
        return (m_sequence.preActionData.playerHealth > m_sequence.postActionData.playerHealth);
    }

    //This method evaluates gamedata based on a specified heuristic.
    public static bool Evaluate(GameData m_gameData, Heuristic m_heuristic)
    {
        return (Evaluate(m_gameData, m_heuristic, 0.5f));

    }

    //This method evaluates gamedata based on a specified heuristic.
    public static bool Evaluate(GameData m_gameData, Heuristic m_heuristic, float m_weight)
    {
        switch (m_heuristic) {
            case Heuristic.NONE:
                return false;
            case Heuristic.WEIGHTED:
                return Random.Range(0, 1) > m_weight;
            case Heuristic.CLOSE:
                if (Vector2.Distance(m_gameData.bossPosition, m_gameData.playerPosition) < CLOSERANGE) { return true; } else { return false; }
        
        }

        return false;

    }
}
