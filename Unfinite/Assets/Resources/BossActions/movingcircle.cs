using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcircle : BossAction
{
    private GameObject crystal;
    private int indexOfPattern;
    public int index, quantity;
    public float distance, speed, direction, rotationSpeed;
    public movingcircle(Boss m_boss) : base(m_boss)
    {
        nodeData = new BossNodeData(new List<BossNodeType>(new BossNodeType[] { BossNodeType.ATTACK, BossNodeType.LONGRANGE }), null, null );
    }

    public override IEnumerator Act()
    {
        Debug.Log("movingcircle");

        crystal = boss.gameObject.transform.GetChild(index).gameObject;
        crystal.GetComponent<generatePatterns>().movingCircle(crystal, quantity, distance, speed, direction, rotationSpeed);
        indexOfPattern = crystal.GetComponent<generatePatterns>().getAmountActiveMovingCircles() - 1;
        crystal.GetComponent<generatePatterns>().startMovingCircleRotation(indexOfPattern);

        yield return new WaitForSeconds(1f);

        base.End();
        yield return null;
    }
}