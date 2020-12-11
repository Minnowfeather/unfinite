using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqiredBossAction1 : BossAction
{
    public ReqiredBossAction1(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.CLOSERANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("ReqiredBossAction1");

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}