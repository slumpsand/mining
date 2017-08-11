using UnityEngine;
using System.Collections.Generic;
using System;

public class Background : MonoBehaviour
{

    public float zPosition = 2f;

    [Header("Diamond Block")]
    public float blockOffset = 3f;

    [Header("Background Sprites")]
    public Sprite groundSprite;
    public Sprite skySprite;
    public Sprite grassSprite;
    public Sprite diamondSprite;

    [HideInInspector]
    public float grassHeight;

    Pair<int> minTiles;
    Pair<int> doneTiles;
    bool isBlockPlaced;

    void Awake()
    {
        doneTiles = new Pair<int>();
        grassHeight = grassSprite.rect.height / grassSprite.pixelsPerUnit;
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
            minTiles.Left + maxSize.Left / 5 - doneTiles.Left,
            minTiles.Right + maxSize.Right / 5 - doneTiles.Right
        );

        new Counter(doTiles.Left - doneTiles.Left).ForEach(i => CreateColumn(-5 * i));
        new Counter(doTiles.Right - doneTiles.Right).ForEach(i => CreateColumn(5 * (i + 1)));

        doneTiles = new Pair<int>(
            doneTiles.Left + doTiles.Left,
            doneTiles.Right + doTiles.Right
        );

        if (!isBlockPlaced)
        {
            isBlockPlaced = true;

            REF.tile.CreateTile("target")
                .SetPosition(-1, REF.map.diamondLevel - blockOffset + grassHeight);
        }
    }

    void CreateColumn(float xvalue)
    {
        int groundCount = REF.map.diamondLevel / 5 - 2;

        CreateTile(xvalue, - 5, skySprite);
        CreateTile(xvalue, 0, grassSprite);

        for (int i = 0; i < groundCount; i++)
        {
            CreateTile(xvalue, i * 5 + grassHeight, groundSprite);
        }

        CreateTile(xvalue, (groundCount + grassHeight - 1) * 5, diamondSprite);
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
            Mathf.FloorToInt(cam.orthographicSize / 5),
            Mathf.FloorToInt((cam.orthographicSize * cam.aspect) / 5)
        );
    }

}