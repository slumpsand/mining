﻿using UnityEngine;
using System;

public class Map : MonoBehaviour
{

    public Side Left { get { return sides.Left; } }
    public Side Right { get { return sides.Right; } }

    public Action<Room> RoomAddedEvent;
    
    Pair<int, int> shopPosition;

    Pair<Side, Side> sides;
    Action<int> SetDrillhead;
    int currentRow;

    void Awake()
    {
        // initilize variables
        RoomAddedEvent = (_) => { };
        sides = new Pair<Side, Side>(new Side(this, false), new Side(this, true));
        CreateShop();

        {
            // initialize the drillhead
            Tile drillhead = REF.tile.CreateTile("drillhead");
            SetDrillhead = (int row) => drillhead.SetPosition(0, row);
            SetDrillhead(0);
        }
    }

    public void UpdateRooms()
    {
        Left.UpdateRooms();
        Right.UpdateRooms();
    }

    public void AddEmptyRow()
    {
        Left.AddEmptyRow();
        Right.AddEmptyRow();

        REF.tile.CreateTile("shaft").SetPosition(0, currentRow);

        SetDrillhead(++currentRow);
    }

    void CreateShop()
    {
        shopPosition = new Pair<int, int>(-1, -2);

        Tile shop = REF.tile.CreateTile("base");
        shop.SetPosition(shopPosition.Left, shopPosition.Right);
    }

}