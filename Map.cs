using System.Collections.Generic;
using UnityEngine;

public class Map
{

    public Side Left { get { return left_rooms; } }
    public Side Right { get { return right_rooms; } }

    private Side left_rooms;
    private Side right_rooms;

    private List<Tile> tiles;
    private Tile drillhead;

    public Map()
    {
        tiles = new List<Tile> ();

        left_rooms = new Side(this, false);
        right_rooms = new Side(this, true);
    }

    public void Setup()
    {
        drillhead = TileManager.GetTile("drillhead");
        drillhead.SetPosition(-1, 0);

        tiles.Add(drillhead);
    }

    private bool wasActiveOnLastFrame = false;
    public void UpdateTiles()
    {
        tiles.ForEach(tile => tile.SetActive(!wasActiveOnLastFrame));
        wasActiveOnLastFrame = !wasActiveOnLastFrame;
    }

    public void UpdateRooms()
    {
        left_rooms.UpdateRooms();
        right_rooms.UpdateRooms();
    }

    public void AddEmptyRow()
    {
        // add the row to the sides
        left_rooms.AddEmptyRow();
        right_rooms.AddEmptyRow();

        // add the shaft room
        int levels = left_rooms.Count;
        Tile tile = TileManager.GetTile("shaft");
        tile.SetPosition(-1, levels - 1);
        tiles.Add(tile);

        // move the drillhead
        drillhead.SetPosition(-1, levels);
    }

    public void AddTile(string name, int x, int y)
    {
        Tile tile = TileManager.GetTile(name);
        tile.SetPosition(x, y);
        
        tiles.Add(tile);
    }

}
