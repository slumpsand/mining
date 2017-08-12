using UnityEngine;

[System.Serializable]
public class BackTile
{
    
    public Sprite sprite;

    [HideInInspector]
    public float width, height;

    void OnValidate()
    {
        width = sprite.rect.width / sprite.pixelsPerUnit;
        height = sprite.rect.height / sprite.pixelsPerUnit;
    }

}