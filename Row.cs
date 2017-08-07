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
        // create the tile
        int column = (side.isRight) ? Size() : -Size();
        GameManager.map.AddTile(room.SpriteName, new Vector2(column, index));

        // add the room to the list
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