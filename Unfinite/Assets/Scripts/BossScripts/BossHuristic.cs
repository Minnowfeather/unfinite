using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BossHeuristic
{
    static string[] heuristics = new string[]{ "none", "close" };

    const int CLOSERANGE = 1;

    //This is a bit of validation to make sure a specified heuristic is accounted for.
    //Add every case of the Evaluate() method to the heuristics array to have it be verified.
    public static bool ValidateHeuristic(string m_heuristic)
    {
        foreach (string heuristic in heuristics)
        {
            if (heuristic == m_heuristic)
            {
                return true;
            }
        }

        return false;
    }

    //This method evaluates gamedata based on a specified heuristic.
    public static bool Evaluate(GameData m_gameData, string m_heuristic)
    {
        switch (m_heuristic) {
            case "none":
                return false;
            case "close":
                if (Vector2.Distance(m_gameData.bossPosition, m_gameData.playerPosition) < CLOSERANGE) { return true; } else { return false; }
        
        }

        return false;

    }
}
