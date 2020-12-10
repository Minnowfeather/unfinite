using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGameStateInterpreter : MonoBehaviour
{
    public GameData InterpretGameState()
    {
        GameData gameData = new GameData();
        gameData.bossHealth = Boss.Current().GetHealth();
        gameData.bossPosition = Boss.Current().gameObject.transform.position;

        return gameData;
    }
}
