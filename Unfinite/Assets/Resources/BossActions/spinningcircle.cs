using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningcircle : BossAction
{
    public int index, quantity;
    public float spawnTime, distance, rotationSpeed;
    private GameObject crystal;
    private int indexOfPattern;
    public spinningcircle(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.MEDIUMRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("spinningcircle");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().spinningCircle(crystal, quantity, spawnTime, distance);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveSpinningCircles() - 1;
        crystal.GetComponent<generatePatterns>().startSpinningCircle(indexOfPattern, rotationSpeed);

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}