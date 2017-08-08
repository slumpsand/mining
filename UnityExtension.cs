using UnityEngine;

static class UnityExtension
{

    // Create a SpriteRenderer from the Sprite and parent it to the TileManager
    public static SpriteRenderer CreateSpriteRenderer(this Sprite sprite)
    {
        var renderer = (SpriteRenderer)new GameObject().AddComponent(typeof(SpriteRenderer));

        renderer.enabled = false;
        renderer.transform.parent = TileManager.instance.transform;
        renderer.sprite = sprite;

        return renderer;
    }

}