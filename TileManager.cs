using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;
using System;
using System.Linq;

public class TileManager : MonoBehaviour
{

    public List<SpriteEntry> sprites;

    private static TileManager _instance;
    private static TileManager instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<TileManager>();
            return _instance;
        }
    }

    public static Tile GetTile(string name)
    { return instance._GetTile(name); }

    private Tile _GetTile(string name)
    {
        // select the correct sprites
        SpriteEntry entry = instance.sprites.FirstOrDefault(en => en.name == name);
        if (entry == null) return null;

        // spawn the sprites
        Image active = Instantiate(entry.active, transform);
        Image notactive = Instantiate(entry.notactive, transform);

        // deactivate them
        active.enabled = false;
        notactive.enabled = false;

        // return the tile
        return new Tile(active, notactive);
    }

    [Serializable]
    public class SpriteEntry
    {
        public string name;
        public Image active, notactive;

        public SpriteEntry(string name, Image active, Image nonactive)
        {
            this.name = name;
            this.active = active;
            this.notactive = nonactive;
        }
    }

}
