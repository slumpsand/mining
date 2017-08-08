using UnityEngine;
using System;

public class Map : MonoBehaviour
{

    public Side Left { get { return sides.Left; } }
    public Side Right { get { return sides.Right; } }

    Pair<Side, Side> sides;
    Action<int> SetDrillhead;
    int currentRow;

    void Start()
    {
        // initilize variables
        sides = new Pair<Side, Side>( new Side(this, false),  new Side(this, true) );

        { 
            // initialize the drillhead
            Tile drillhead = REF.tile.CreateTile("drillhead");
            SetDrillhead = (int row) => drillhead.SetPosition(-1, row);
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

        REF.tile.CreateTile("shaft").SetPosition(-1, currentRow);

        SetDrillhead(++currentRow);
    }

}