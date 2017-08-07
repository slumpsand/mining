using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;
using System;
using System.Linq;

public class TileManager : MonoBehaviour
{

    public List<SpriteEntry> sprites;

    private static TileManager _instance;
    public static TileManager instance
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
        SpriteRenderer active = (SpriteRenderer)new GameObject(name + "_active").AddComponent(typeof(SpriteRenderer));
        SpriteRenderer notactive = (SpriteRenderer)new GameObject(name + "_notactive").AddComponent(typeof(SpriteRenderer));

        // deactivate them
        active.enabled = false;
        notactive.enabled = false;

        // set the parent object
        active.transform.parent = transform;
        notactive.transform.parent = transform;

        // set the sprites
        active.sprite = entry.active;
        notactive.sprite = entry.notactive;

        // return the tile
        return new Tile(active, notactive);
    }

    [Serializable]
    public class SpriteEntry
    {
        public string name;
        public Sprite active, notactive;

        public SpriteEntry(string name, Sprite active, Sprite nonactive)
        {
            this.name = name;
            this.active = active;
            this.notactive = nonactive;
        }
    }

}
