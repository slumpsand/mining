
public abstract class Room
{

    public Row row;

    public readonly int Size;
    public readonly string SpriteName;

    public Room(int Size, string SpriteName)
    {
        this.Size = Size;
        this.SpriteName = SpriteName;
    }

    public abstract void UpdateRoom();

}