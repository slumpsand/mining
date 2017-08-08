using UnityEngine;

using System.Linq;
using System.Collections.Generic;
using System;

public class TileManager : MonoBehaviour
{

    public int activeSortingOrder = 2;
    public int notactiveSortingOrder = 1;
    public List<SpriteEntry> sprites = new List<SpriteEntry>();

    List<SpriteRenderer> activeSprites = new List<SpriteRenderer>();

    SpriteRenderer CreateSpriteRenderer(Sprite sprite, bool isActive)
    {
        var renderer = (SpriteRenderer)new GameObject().AddComponent(typeof(SpriteRenderer));

        renderer.enabled = !isActive;
        renderer.transform.parent = transform;
        renderer.sprite = sprite;
        renderer.sortingOrder = (isActive) ? activeSortingOrder : notactiveSortingOrder;

        if(isActive) activeSprites.Add(renderer);
        return renderer;
    }

    /// <exception cref="SpriteNotRegisteredException" />
    public Tile CreateTile(string name)
    {
        SpriteEntry entry;
        try
        {
            entry = sprites.First(e => e.name == name);
        } catch (InvalidOperationException inner) {
            throw new SpriteNotRegisteredException(name, inner);
        }

        var active = CreateSpriteRenderer(entry.active, true);
        var notactive = CreateSpriteRenderer(entry.notactive, false);
        
        return new Tile(active, notactive);
    }

    bool wasActiveOnLastFrame;
    public void UpdateTiles()
    {
        wasActiveOnLastFrame = !wasActiveOnLastFrame;
        activeSprites.ForEach(s => s.enabled = wasActiveOnLastFrame);
    }

    public void AddTile(string name, bool isRight, int column, int row, int size)
    {
        Tile tile = CreateTile(name);

        if (isRight)
        {
            tile.SetPosition(column + 1, row);
        } else
        {
            tile.SetPosition(-column - size, row);
        }
    }

}