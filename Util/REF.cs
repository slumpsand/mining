using UnityEngine;
using System.Collections.Generic;

public class REF : MonoBehaviour
{

    static Dictionary<System.Type, Object> singletons = new Dictionary<System.Type, Object>();
    static T FindSingleton<T>()
        where T : Object
    {
        if (singletons.ContainsKey(typeof(T)))
            return (T) singletons[typeof(T)];

        T[] all = Resources.FindObjectsOfTypeAll<T>();

        if (all.Length == 0) throw new SingletonBrokenException(typeof(T));
        if (all.Length > 1) throw new SingletonBrokenException(typeof(T), all.Length);

        singletons[typeof(T)] = all[0];
        return all[0];
    }

    public static Map map
    {
        get { return FindSingleton<Map>(); }
    }

    public static GameManager game
    {
        get { return FindSingleton<GameManager>(); }
    }

    public static TileManager tile
    {
        get { return FindSingleton<TileManager>(); }
    }

    public static ConfigManager config
    {
        get { return FindSingleton<ConfigManager>(); }
    }

    public static CameraController cam
    {
        get { return FindSingleton<CameraController>(); }
    }

    public static Background back
    {
        get { return FindSingleton<Background>(); }
    }

}