using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : BossAction
{
    public int index;
    public float speed, dR;
    private GameObject crystal;
    public aim(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("aim");

        crystal = boss.Current().gameObject.transform.getChild(index);
        crystal.GetComponent<generatePatterns>().fireBullet(crystal, speed, dR);
        
        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}