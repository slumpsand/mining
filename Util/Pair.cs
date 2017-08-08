using System;

[Serializable]
public class Pair<A, B>
{
    public A Left;
    public B Right;

    public Pair() { }

    public Pair(A left, B right)
    {
        Left = left;
        Right = right;
    }
}