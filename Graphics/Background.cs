using UnityEngine;
using System.Collections.Generic;

public class Background : MonoBehaviour
{
   
    public Sprite groundSprite;
    public Sprite skySprite;
    public Sprite grassSprite;
    public Sprite diamondSprite;

    public int minTilesLeft = 3;
    public int minTilesRight = 3;

    List<GameObject> tiles;

    void Awake()
    {
        tiles = new List<GameObject>();
    }

    void Start()
    {
        RecalculateBackground();
        REF.map.RoomAddedEvent += (_) => RecalculateBackground();
    }

    void RecalculateBackground()
    {
        int maxLeft = REF.map.Left.FindMaxSize();
        int maxRight = REF.map.Right.FindMaxSize();

        int placeLeft = minTilesLeft + maxLeft / 5;
        int placeRight = minTilesRight-1 + maxRight / 5;

        List<GameObject> newtiles = new List<GameObject>();

        for(int i=0; i<placeLeft; i++)
        {
            newtiles.AddRange(CreateColumn(i * -5));
        }

        for(int i=0; i<placeRight; i++)
        {
            newtiles.AddRange(CreateColumn(i * 5 + 5));
        }

        foreach(var tile in tiles)
        {
            Destroy(tile);
        }

        tiles = newtiles;
    }

    List<GameObject> CreateColumn(float x)
    {
        List<GameObject> newtiles = new List<GameObject>();

        newtiles.Add(CreateTile(x, 5f, skySprite));
        newtiles.Add(CreateTile(x, 0, grassSprite));

        for (int i=1; i<(REF.map.diamondLevel / 5); i++)
        {
            newtiles.Add(CreateTile(x, i * -5, groundSprite));
        }

        newtiles.Add(CreateTile(x, -REF.map.diamondLevel, diamondSprite));

        return newtiles;
    }

    GameObject CreateTile(float x, float y, Sprite sprite)
    {
        var renderer = (SpriteRenderer)new GameObject().AddComponent(typeof(SpriteRenderer));

        renderer.transform.position = new Vector3(x, y + 1.25f, 2);
        renderer.transform.parent = transform;
        renderer.sprite = sprite;

        return renderer.gameObject;
    }

}