using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMemory
{
    List<List<BossSequence>> memory = new List<List<BossSequence>>();
    int memSize = 1;

    public BossMemory() { }
    public BossMemory(int m_memSize)
    {
        memSize = m_memSize;
    }

    public void Record(BossSequence m_sequence)
    {
        memory[memory.Count - 1].Add(m_sequence);
    }

    public void NewGame()
    {
        while (memory.Count >= memSize)
        {
            memory.RemoveAt(0);
        }

        memory.Add(new List<BossSequence>());
    }

    public List<BossSequence> Read()
    {
        List<BossSequence> sequences = new List<BossSequence>();
        foreach (List<BossSequence> sequence in memory)
        {
            sequences.AddRange(sequence);
        }

        return sequences;
    }
}
