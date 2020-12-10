using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BossHeuristic
{
    public enum Heuristic
    {
        NONE,
        CLOSE
    }

    const int CLOSERANGE = 1;

    //This method evaluates gamedata based on a specified heuristic.
    public static bool Evaluate(GameData m_gameData, Heuristic m_heuristic)
    {
        switch (m_heuristic) {
            case Heuristic.NONE:
                return false;
            case Heuristic.CLOSE:
                if (Vector2.Distance(m_gameData.bossPosition, m_gameData.playerPosition) < CLOSERANGE) { return true; } else { return false; }
        
        }

        return false;

    }
}
