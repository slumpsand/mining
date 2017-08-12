using UnityEngine;
using System;

public class Map : MonoBehaviour
{

    public Side Left { get { return sides.Left; } }
    public Side Right { get { return sides.Right; } }

    public Action<Room> RoomAddedEvent;
    public int diamondLevel = 20;

    Pair<Side> sides;
    Action<int> SetDrillhead;
    int currentRow;

    void Awake()
    {
        // initilize variables
        RoomAddedEvent = (_) => { };
        sides = new Pair<Side>(new Side(this, false), new Side(this, true));

        // create static tiles
        CreateShop();
        CreateLandingSite();
        InitializeDrillhead();
    }

    void Start()
    {
        REF.tile.CreateTile("shaft").SetPosition(0, 0);
    }

    void InitializeDrillhead()
    {
        Tile drillhead = REF.tile.CreateTile("drillhead");
        SetDrillhead = (int row) => drillhead.SetPosition(0, row+1);
        SetDrillhead(0);
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

        REF.tile.CreateTile("shaft").SetPosition(0, currentRow+1);

        SetDrillhead(++currentRow);
    }

    void CreateShop()
    {
        Tile shop = REF.tile.CreateTile("base");
        shop.SetPosition(-1, -2);
    }


    void CreateLandingSite()
    {
        Tile landing = REF.tile.CreateTile("landing");
        landing.SetPosition(-3, -1);
    }

    public Pair<int> FindMaxSize()
    {
        return new Pair<int>(
            Left.FindMaxSize(),
            Right.FindMaxSize()
        );
    }

}