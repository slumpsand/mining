using UnityEngine;
using System.Collections.Generic;
using System;

public class Background : MonoBehaviour
{

    public float zPosition = 2f;
    public float blockOffset = 3f;

    [Space]
    public BackTile groundTile;
    public BackTile skyTile;
    public BackTile grassTile;
    public BackTile diamondTile;

    [HideInInspector]
    public float tileWidth;

    Pair<int> minTiles;
    Pair<int> doneTiles;
    bool isBlockPlaced;

    void Awake()
    {
        doneTiles = new Pair<int>();

        if (groundTile.width != skyTile.width) throw new UnevenTileWidthException(groundTile, skyTile);
        if (groundTile.width != grassTile.width) throw new UnevenTileWidthException(groundTile, grassTile);
        if (groundTile.width != diamondTile.width) throw new UnevenTileWidthException(groundTile, diamondTile);

        tileWidth = groundTile.width;
    }

    void Start()
    {
        CalculateMinTiles();

        RecalculateBackground();
        REF.map.RoomAddedEvent += (_) => RecalculateBackground();
    }

    void RecalculateBackground()
    {
        var maxSize = REF.map.FindMaxSize();

        var doTiles = new Pair<int>(
            Mathf.FloorToInt(minTiles.Left + maxSize.Left / tileWidth - doneTiles.Left),
            Mathf.FloorToInt(minTiles.Right + maxSize.Right / tileWidth - doneTiles.Right)
        );

        new Counter(doTiles.Left - doneTiles.Left).ForEach(i => CreateColumn(-tileWidth * i));
        new Counter(doTiles.Right - doneTiles.Right).ForEach(i => CreateColumn(tileWidth * (i + 1)));

        doneTiles = new Pair<int>(
            doneTiles.Left + doTiles.Left,
            doneTiles.Right + doTiles.Right
        );

        if (!isBlockPlaced)
        {
            isBlockPlaced = true;

            REF.tile.CreateTile("target")
                .SetPosition(-1, REF.map.diamondLevel - blockOffset + grassTile.height);
        }
    }

    void CreateColumn(float xvalue)
    {
        int groundCount = REF.map.diamondLevel / 5 - 2;

        CreateTile(xvalue, - skyTile.height, skyTile.sprite);
        CreateTile(xvalue, 0, grassTile.sprite);

        for (int i = 0; i < groundCount; i++)
        {
            CreateTile(xvalue, i * groundTile.height + grassTile.height, groundTile.sprite);
        }

        CreateTile(xvalue, (groundCount - 1) * groundTile.height + grassTile.height, diamondTile.sprite);
    }

    int currentTileIndex;
    void CreateTile(float xvalue, float yvalue, Sprite sprite)
    {
        var renderer = (SpriteRenderer)new GameObject((currentTileIndex++).ToString("0000"))
            .AddComponent(typeof(SpriteRenderer));

        renderer.transform.position = new Vector3(xvalue, -yvalue, zPosition);
        renderer.transform.parent = transform;
        renderer.sprite = sprite;
    }

    void CalculateMinTiles()
    {
        Camera cam = REF.cam.GetComponent<Camera>();
        minTiles = new Pair<int>(
            Mathf.FloorToInt(cam.orthographicSize / tileWidth),
            Mathf.FloorToInt((cam.orthographicSize * cam.aspect) / tileWidth)
        );
    }

}