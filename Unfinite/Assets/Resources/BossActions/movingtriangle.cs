using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingtriangle : BossAction
{
    private GameObject crystal;
    private int indexOfPattern;
    public int index, quantity;
    public float width, height, speed, direction;
    public movingtriangle(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.LONGRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("movingtriangle");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().movingTriangle(crystal, quantity, width, height, speed, direction);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveMovingTriangles() - 1;

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}