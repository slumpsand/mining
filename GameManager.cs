using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float tileUpdateDelay = 0.5f;
    public float roomUpdateDelay = 0.5f;

    private static GameManager _instance;
    private static GameManager instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    private float _ore;
    public static float ore
    {
        get { return instance._ore; }
    }

    private float _speed;
    public static float speed
    {
        get { return instance._speed; }
    }

    public static void AddOre(float ore)
    {
        if (ore <= 0)
        {
            throw new ArgumentException("can't be zero or less", "ore");
        }

        instance._ore += ore;
    }

    public static void AddSpeed(float speed)
    {
        if (speed <= 0)
        {
            throw new ArgumentException("can't be zero or less", "speed");
        }

        instance._speed += speed;
    }

    private float tileLastUpdateTime;
    private float roomLastUpdateTime;
    void Update()
    {
        if (Time.time - tileLastUpdateTime >= tileUpdateDelay)
        {
            tileLastUpdateTime = Time.time;

            REF.tile.UpdateTiles();
        }

        if (Time.time - roomLastUpdateTime >= roomUpdateDelay)
        {
            roomLastUpdateTime = Time.time;

            REF.map.UpdateRooms();
        }
    }

}