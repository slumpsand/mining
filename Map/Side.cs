﻿using System.Collections;
using System.Collections.Generic;

public class Side
{

    public readonly bool isRight;
    public Map map;

    private List<Row> rows;

    public Side(Map map, bool isRight)
    {
        this.map = map;
        this.isRight = isRight;

        rows = new List<Row>();
    }

    public int Count
    {
        get { return rows.Count; }
    }

    public void UpdateRooms()
    {
        rows.ForEach(row => row.UpdateRooms());
    }

    public void AddEmptyRow()
    {
        rows.Add(new Row(this, Count));
    }

    public Row this[int index]
    {
        get
        {
            return rows[index];
        }
    }

    public int FindMaxSize()
    {
        int maxSize = 0;
        foreach(var row in rows)
        {
            int size = row.Size();
            maxSize = (size > maxSize) ? size : maxSize;
        }

        return maxSize;
    }

}
