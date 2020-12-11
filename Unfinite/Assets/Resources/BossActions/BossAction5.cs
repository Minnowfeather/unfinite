using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction5 : BossAction
{
    public BossAction5(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("BossAction5");

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}