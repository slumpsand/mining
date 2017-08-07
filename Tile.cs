using UnityEngine;
using UnityEngine.UI;

public class Tile
{

    public Image active;
    public Image notactive;

    public Tile(Image active, Image notactive)
    {
        active.enabled = false;
        active.enabled = false;

        this.active = active;
        this.notactive = notactive;
    }

    public void SetActive(bool isActive)
    {
        active.enabled = isActive;
        notactive.enabled = !isActive;
    }

}