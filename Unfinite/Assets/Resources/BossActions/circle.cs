using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : BossAction
{
    public int index, amount;
    public float speed, dR;
    private GameObject crystal;
    public circle(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.MEDIUMRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("circle");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().circle(crystal, amount, speed, dR);

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}