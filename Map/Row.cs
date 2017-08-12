using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Row : IEnumerable
{

    public Side side;
    public readonly int index;

    private List<Room> rooms;

    public Row(Side side, int index)
    {
        this.side = side;
        this.index = index;

        this.rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        REF.tile.AddTile(room.SpriteName, side.isRight, Size(), index + REF.back.grassTile.height, room.Size);

        room.row = this;
        room.index = Size();
        rooms.Add(room);
        
        REF.map.RoomAddedEvent(room);
    }

    public int Count()
    {
        return rooms.Count();
    }

    public int Size()
    {
        return rooms.Sum(room => room.Size);
    }

    public void UpdateRooms()
    {
        rooms.ForEach(room => room.UpdateRoom());
    }

    public IEnumerator GetEnumerator()
    {
        return rooms.GetEnumerator();
    }

    public Room this[int index]
    {
        get
        {
            return rooms[index];
        }
    }
}