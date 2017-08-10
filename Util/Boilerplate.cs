using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

[Serializable]
public struct SpriteEntry
{
    public string name;
    public Sprite active;
    public Sprite notactive;
}

public class Counter : IEnumerator<int>, IEnumerable<int>
{
    public readonly int MaxValue;

    public Counter(int MaxValue)
    {
        this.MaxValue = MaxValue;
    }

    public int Current
    {
        get;
        private set;
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        Current++;
        return Current < MaxValue;
    }

    public void Reset()
    {
        Current = 0;
    }

    public void ForEach(Action<int> action)
    {
        if (action == null) return;
        foreach(int i in this)
        {
            action(i);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new Counter(MaxValue);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Counter(MaxValue);
    }
}