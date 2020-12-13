using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone : BossAction
{
    private GameObject crystal;
    public int index, quantity;
    private int indexOfPattern;
    public float interval, speed, offset, rotationSpeed, spread; 
    public cone(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.MEDIUMRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("cone");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().cone(crystal, quantity, interval, speed, offset, rotationSpeed, spread);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveCones() - 1;

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}