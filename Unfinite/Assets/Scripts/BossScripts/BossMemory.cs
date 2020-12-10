using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMemory
{
    Queue<BossSequence> memory = new Queue<BossSequence>();
    int memSize = 1;

    public BossMemory() { }
    public BossMemory(int m_memSize)
    {
        memSize = m_memSize;
    }

    public void Record(BossSequence m_sequence)
    {
        memory.Enqueue(m_sequence);
        while (memory.Count > memSize)
        {
            memory.Dequeue();
        }
    }

    public BossSequence[] Read()
    {
        return memory.ToArray();
    }
}
