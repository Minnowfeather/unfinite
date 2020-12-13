using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletline : BossAction
{
    private GameObject crystal;
    private int indexOfPattern;
    public int index, numLines, numBullets;
    public float spacing, spawnTime, offset, rotationSpeed;
    public bulletline(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.LONGRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("bulletline");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().bulletLine(crystal, numLines, numBullets, spacing, spawnTime, offset);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveBulletLines() - 1;
        crystal.GetComponent<generatePatterns>().startBulletLineRotation(indexOfPattern, rotationSpeed);

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}