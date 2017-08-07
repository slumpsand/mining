﻿using System.Collections.Generic;
using UnityEngine;

public class Map
{

    public Side Left { get { return left_rooms; } }
    public Side Right { get { return right_rooms; } }

    private Side left_rooms;
    private Side right_rooms;

    private List<Tile> tiles;

    public Map()
    {
        tiles = new List<Tile>();

        left_rooms = new Side(this);
        right_rooms = new Side(this);
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
        left_rooms.AddEmptyRow();
        right_rooms.AddEmptyRow();
    }

    public void AddTile(string name, Vector2 position)
    {
        Tile tile = TileManager.GetTile(name);

        tile.active.transform.position += new Vector3(position.x, 0, position.y);
        tile.notactive.transform.position += new Vector3(position.x, 0, position.y);

        tiles.Add(tile);
    }

}
