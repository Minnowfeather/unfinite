using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction : BossDecisionNode
{
    // added public to fix scoping 
    public Boss boss;

    public BossAction(Boss m_boss) : base()
    {
        boss = m_boss;
    }

    public virtual IEnumerator Act()
    {
        //End();
        yield return null;
    }

    public void End()
    {
        BossSequence sequence = GetSequence();
        sequence.postActionData = boss.interpreter.InterpretGameState();
        SetSequence(sequence);
        boss.RecordResult(GetSequence());
    }
}
