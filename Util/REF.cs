using UnityEngine;

public class REF : MonoBehaviour
{

    static Map _map;
    public static Map map
    {
        get
        {
            if (_map == null) _map = FindObjectOfType<Map>();
            return _map;
        }
    }

    static GameManager _game;
    public static GameManager game
    {
        get
        {
            if (_game == null) _game = FindObjectOfType<GameManager>();
            return _game;
        }
    }

    static TileManager _tile;
    public static TileManager tile
    {
        get
        {
            if (_tile == null) _tile = FindObjectOfType<TileManager>();
            return _tile;
        }
    }

    static ConfigManager _config;
    public static ConfigManager config
    {
        get
        {
            if (_config == null) _config = FindObjectOfType<ConfigManager>();
            return _config;
        }
    }

    static CameraController _cam;
    public static CameraController cam
    {
        get
        {
            if (_cam == null) _cam = FindObjectOfType<CameraController>();
            return _cam;
        }
    }

}