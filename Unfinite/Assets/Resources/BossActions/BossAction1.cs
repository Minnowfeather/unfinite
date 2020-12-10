using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction1 : BossAction
{
    public BossAction1(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK }), null, null );
    }

    public override IEnumerator Act()
    {

        base.End();
        yield return null;
    }
}
