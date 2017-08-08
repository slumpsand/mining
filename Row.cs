using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Row
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
        REF.tile.AddTile(room.SpriteName, side.isRight, Size(), index, room.Size);

        room.row = this;
        rooms.Add(room);
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

    public Room this[int index]
    {
        get
        {
            return rooms[index];
        }
    }
}