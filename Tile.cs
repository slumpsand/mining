﻿using UnityEngine;
using UnityEngine.UI;

public class Tile
{

    public SpriteRenderer active;
    public SpriteRenderer notactive;

    public Tile(SpriteRenderer active, SpriteRenderer notactive)
    {
        active.enabled = false;
        active.enabled = false;

        this.active = active;
        this.notactive = notactive;
    }

    public void SetActive(bool isActive)
    {
        active.enabled = isActive;
        notactive.enabled = !isActive;
    }

    public void SetPosition(int x, int y)
    {
        if (x > 0) x++;

        active.transform.position = new Vector3(x, -y);
        notactive.transform.position = new Vector3(x, -y);
    }

}