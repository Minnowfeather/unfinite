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
        Debug.Log("Action 1");

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}
