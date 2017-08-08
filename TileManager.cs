using UnityEngine;

using System.Linq;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Map))]
public class TileManager : MonoBehaviour
{

    public List<Entry> sprites;

    void Start()
    {
        sprites = new List<Entry>();
    }

    public static Tile GetTile(string name)
    {
        var entry = instance.sprites.FirstOrDefault(e => e.name == name);
        if (entry == null) return null;

        var active = entry.active.CreateSpriteRenderer();
        var notactive = entry.notactive.CreateSpriteRenderer();

        return new Tile(active, notactive);
    }

    bool wasAcitveOnLastFrame;
    public static void UpdateTiles()
    {
        instance.tiles.ForEach(tile => tile.SetActive(!instance.wasAcitveOnLastFrame));
        instance.wasAcitveOnLastFrame = !instance.wasAcitveOnLastFrame;
    }

    [Serializable]
    public class Entry
    {
        public string name;
        public Sprite active;
        public Sprite notactive;
    }

    private static TileManager _instance;
    public static TileManager instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<TileManager>();
            return _instance;
        }
    }

}
