using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredAction2 : BossAction
{
    public RequiredAction2(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.RETREAT }), null, null );
    }

    public override IEnumerator Act()
    {
        

        base.End();
        yield return null;
    }
}