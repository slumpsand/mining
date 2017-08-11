using UnityEngine;
using System.Collections.Generic;

public class REF : MonoBehaviour
{

    static Dictionary<System.Type, Object> singletons = new Dictionary<System.Type, Object>();
    static T FindReference<T>()
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
        get { return FindReference<Map>(); }
    }

    public static GameManager game
    {
        get { return FindReference<GameManager>(); }
    }

    public static TileManager tile
    {
        get { return FindReference<TileManager>(); }
    }

    public static ConfigManager config
    {
        get { return FindReference<ConfigManager>(); }
    }

    public static CameraController cam
    {
        get { return FindReference<CameraController>(); }
    }

}