using UnityEngine;
using System.Collections.Generic;

public class Init : MonoBehaviour
{
    void Start()
    {
        for(int i=0; i<20; i++)
        {
            REF.map.AddEmptyRow();
        }

        RowLeft1();
        RowRight2();
        RowRight1();
        RowLeft3();
    }

    void RowLeft1()
    {
        var rooms = new List<Room> { new BedRoom(), new MineRoom() };
        rooms.ForEach(room => REF.map.Left[0].AddRoom(room));
    }

    void RowLeft3()
    {
        for (int i=0; i<10; i++)
        {
            REF.map.Left[2].AddRoom(new MineRoom());
        }
    }

    void RowRight1()
    {
       var rooms = new List<Room> { new ResearchRoom(), new MineRoom() };
        rooms.ForEach(room => REF.map.Right[0].AddRoom(room));
    }

    void RowRight2()
    {
        var rooms = new List<Room> { new BedRoom(), new ResearchRoom() };
        rooms.ForEach(room => REF.map.Right[1].AddRoom(room));
    }
}
