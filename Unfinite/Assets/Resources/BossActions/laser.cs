using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : BossAction
{
    private GameObject crystal;
    public int index, quantity;
    public float spawnTime, rotationSpeed, offset, length;
    private int indexOfPattern;
    public laser(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.MEDIUMRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("laser");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().laser(crystal, quantity, spawnTime, rotationSpeed, offset, length);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveLasers() - 1;
        crystal.GetComponent<generatePatterns>().resumeLaser(index);

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}