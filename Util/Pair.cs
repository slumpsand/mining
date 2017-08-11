using System;

[Serializable]
public class Pair<A>
{
    public A Left, Right;

    public Pair() { }

    public Pair(A left, A right)
    {
        Left = left;
        Right = right;
    }

    public void Both(Action<A> func)
    {
        func(Left);
        func(Right);
    }

    public void Both(Action<A, bool> func)
    {
        func(Left, false);
        func(Right, true);
    }
}