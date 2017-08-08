using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Init : MonoBehaviour
{
    void Start()
    {
        REF.map.AddEmptyRow();
        REF.map.AddEmptyRow();

        List<Room> row1 = new List<Room> { new MineRoom(), new BedRoom() };
        List<Room> row2 = new List<Room> { new ResearchRoom(), new MineRoom() };
        List<Room> row3 = new List<Room> { new BedRoom(), new ResearchRoom() };

        row1.ForEach(room => REF.map.Right[0].AddRoom(room));
        row2.ForEach(room => REF.map.Left[0].AddRoom(room));
        row3.ForEach(room => REF.map.Right[1].AddRoom(room));
    }
}
