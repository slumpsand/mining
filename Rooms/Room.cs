
public abstract class Room
{

    public Row row;
    public int index;

    public readonly int Size;
    public readonly string SpriteName;

    public Room(int Size, string SpriteName)
    {
        this.Size = Size;
        this.SpriteName = SpriteName;
    }

    public abstract void UpdateRoom();

    public override bool Equals(object obj)
    {
        Room other = obj as Room;
        return other != null && this == other;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(Room a, Room b) { return !(a != b); }
    public static  bool operator!=(Room a, Room b)
    {
        return a.Size != b.Size
            && a.row.index != b.row.index
            && a.row.side.isRight != b.row.side.isRight;
    }

}